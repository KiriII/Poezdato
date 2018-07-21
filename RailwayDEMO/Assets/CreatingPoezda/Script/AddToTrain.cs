using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using train;

public class AddToTrain : MonoBehaviour {

    private CreatingSystem Cs;
    public snake lokomotiw;
    public Transform it;
    bool wait;


    // Use this for initialization
    void Start () {
        wait = false;
        Cs = FindObjectOfType<CreatingSystem>();
        it = this.gameObject.transform;
        it.position = new Vector3(it.position.x - Cs.range/1.5f - Cs.width/2 , it.position.y , it.position.z);
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Jop");
        if ((other.tag == "Wagonchik") && (!wait))
        {
            lokomotiw.Wagoni.Add(other.gameObject);
            lokomotiw.InitArrays();
            it.position = new Vector3(it.position.x - Cs.range - Cs.width, it.position.y, it.position.z);
            other.gameObject.GetComponent<snake>().speed = 0;
            lokomotiw.WagoniNeeded[other.gameObject.GetComponent<Train>().ID - 1] -= 1;
            bool end = true;
            for (int i = 0; i < lokomotiw.WagoniNeeded.Count; i++)
            {
                if (lokomotiw.WagoniNeeded[i] > 0)
                {
                    end = false;
                } 
            }
            if ((end) || (lokomotiw.Wagoni.Count == Cs.maxSize))
            {
                lokomotiw.GetComponent<snake>().speed = 50;
                wait = true;
            }
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
