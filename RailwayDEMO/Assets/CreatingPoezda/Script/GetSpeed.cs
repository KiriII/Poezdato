using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewBehaviourScript : MonoBehaviour {

    private CreatingSystem creatingSystem;
    private float speed;

	// Use this for initialization
	void Start () {
        creatingSystem = FindObjectOfType<CreatingSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        speed = creatingSystem.Wagoni[0].GetComponent<snake>().speed;
        this.gameObject.GetComponent<Text>().text = "" + speed;
	}
}
