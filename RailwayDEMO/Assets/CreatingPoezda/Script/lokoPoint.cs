using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lokoPoint : MonoBehaviour {

    public AddToTrain current;
    [HideInInspector]
    public List<int> ForUI;
    private CreatingSystem Cs;
    private bool sad; 

    void Start()
    {
        sad = false;
        Cs = FindObjectOfType<CreatingSystem>();
    }

        private void OnMouseDown()
    {
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
}
