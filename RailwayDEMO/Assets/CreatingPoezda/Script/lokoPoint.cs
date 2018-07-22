using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lokoPoint : MonoBehaviour {

    [Range(1, 5)]
    public int lineNumber = 1;
    public AddToTrain current;
    [HideInInspector]
    public List<int> ForUI;
    private CreatingSystem Cs;
    private bool sad;
    //[HideInInspector]
    public int self;

    void Start()
    {
        self = lineNumber;
        sad = false;
        Cs = FindObjectOfType<CreatingSystem>();
    }

    private void OnMouseDown()
    {
        Cs.line.text = "Линия " +  self;
        for (int i = 0; i < Cs.sostawCount; i++)
        {
            if (!sad)
            {
                GameObject currentWagon = Instantiate(Cs.choseble[i], Cs.NeedPlaces[i].transform);
            }

            Cs.NeedTextes[i].text = "X" + ForUI[i];
        }
        sad = true;
    }

    public void ChangeExistWagoni()
    {
        if (sad = true)
        {
            for (int i = 0; i < Cs.sostawCount; i++)
            {
                if (ForUI[i] >= 0) Cs.NeedTextes[i].text = "X" + ForUI[i];
                else Cs.NeedTextes[i].text = "X" + 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered line " + lineNumber);
        if (other.gameObject.GetComponent<train.Train>() != null)
            other.gameObject.GetComponent<train.Train>().CurrentLine = lineNumber;
    }
}
