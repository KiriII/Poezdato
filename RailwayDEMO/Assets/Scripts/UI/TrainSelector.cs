using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSelector : MonoBehaviour {
	
	void Start () 
	{
        EventHandler.OnCreating += HideOrShow;
        gameObject.SetActive(false);
	}

	private void OnDisable() 
	{
		EventHandler.OnCreating += HideOrShow;
	}

	private void HideOrShow(bool show)
	{
		gameObject.SetActive(show);
	}
}
