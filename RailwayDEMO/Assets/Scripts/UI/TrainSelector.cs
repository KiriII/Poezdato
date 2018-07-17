using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSelector : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		TrainHandler.OnDeparture += Close;
	}

	private void Close()
	{
		gameObject.SetActive(false);
	}
}
