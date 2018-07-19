using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSelector : MonoBehaviour {
	
	void Start () 
	{
		TrainHandler.OnDeparture += Close;
	}

	private void OnDisable() 
	{
		TrainHandler.OnDeparture -= Close;
	}

	private void Close()
	{
		gameObject.SetActive(false);
	}
}
