using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using train;

public class AddToTrain : MonoBehaviour {

    private CreatingSystem Cs;
    public snake lokomotiw;
    public Transform it;
    bool wait;
    public lokoPoint loko;


    // Use this for initialization
    void Start () {
        wait = false;
        Cs = FindObjectOfType<CreatingSystem>();
        it = this.gameObject.transform;
        it.position = new Vector3(it.position.x - Cs.range/1.5f - Cs.width/2 , it.position.y , it.position.z);
        //loko.ExistForUI = GetExistWagoni();

        EventHandler.OnFullLineCompleted += StartMovement;
    }

    private void OnDisable()
    {
        EventHandler.OnFullLineCompleted -= StartMovement;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Wagonchik") && (!wait))
        {
            lokomotiw.Wagoni.Add(other.gameObject);
            lokomotiw.InitArrays();
            it.position = new Vector3(it.position.x - Cs.range - Cs.width, it.position.y, it.position.z);
            
            other.gameObject.GetComponent<Train>().SetSpeed(0);
            EventHandler.LineChanged(other.gameObject);
            
            lokomotiw.WagoniNeeded[other.gameObject.GetComponent<Train>().ID - 1] -= 1;
            bool end = true;
            for (int i = 0; i < lokomotiw.WagoniNeeded.Count; i++)
            {
                if (lokomotiw.WagoniNeeded[i] > 0)
                {
                    end = false;
                } 
            }
           // if ("Линия " + loko.self == Cs.line.text) loko.ChangeExistWagoni();
            /*
            if ((end) || (lokomotiw.Wagoni.Count == Cs.maxSize))
            {
                lokomotiw.GetComponent<snake>().speed = 50;
                wait = true;
            }
            */
        }
    }

    private void StartMovement(FullLineTask completedTask)
    {        
        if (completedTask.LineNumber == lokomotiw.GetComponent<Train>().CurrentLine)
        {
            lokomotiw.GetComponent<Train>().SetSpeed( 50 );
            wait = true;
            if (completedTask.Completed)
            {
                Debug.Log("PERFECT!!!");
            }
            else
            {
                Debug.Log("BAD!!!");
            }
            completedTask.ResetTask();
        }

    }

    private void Update()
    {
        if (wait) {
            if (lokomotiw.GetComponent<snake>().Wagoni[lokomotiw.GetComponent<snake>().Wagoni.Count - 1].transform.position.x >
                Cs.trainsStarts[lokomotiw.GetComponent<snake>().lokoPoint].transform.position.x + Cs.width)
            {
                wait = false;
                Cs.End(lokomotiw);
            }
        }
    }
}
