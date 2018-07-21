using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	private Animator anim;

	private void Start() 
	{
		anim = GetComponent<Animator>();	
		anim.SetInteger("direction", -1);
		
		Time.timeScale = 0f;
		EventHandler.TimeScaleChanged(Time.timeScale);
	}	

	public void Begin()
	{
		anim.SetInteger("direction", 1);
		Time.timeScale = 1;
		EventHandler.TimeScaleChanged(Time.timeScale);
		EventHandler.StartEvent();
	}
}
