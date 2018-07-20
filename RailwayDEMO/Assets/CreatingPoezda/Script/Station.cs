using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : Interactable {

    private CreatingSystem Cs;
    public GameObject startPoint;
    public int number;

	// Use this for initialization
	void Start () {
        Cs = FindObjectOfType<CreatingSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (!Cs.isCreating)
        {
            Cs.StartCreating(startPoint, number);
        }
    }
}
