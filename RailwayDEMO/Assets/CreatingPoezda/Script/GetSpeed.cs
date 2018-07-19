using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    private CreatingSystem creatingSystem;
    private float speed;
    private Text text;

	private train.Train mainTrain;

	// Use this for initialization
	void Start () 
	{
        creatingSystem = FindObjectOfType<CreatingSystem>();
		text = GetComponent<Text>();
		mainTrain = creatingSystem.Wagoni[0].GetComponent<train.Train>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		speed = mainTrain.CurrentSpeed;
		text.text = "Train's speed" + speed;
	}
}
