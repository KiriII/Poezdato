using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	private Animator anim;

    private CreatingSystem Cs;
    public GameObject startPoint;
    public int number;


    private void Start() 
	{
		anim = GetComponent<Animator>();	
		anim.SetInteger("direction", -1);
		
		Time.timeScale = 0f;
		//EventHandler.TimeScaleChanged(Time.timeScale);

        Cs = FindObjectOfType<CreatingSystem>();
    }	

	public void Begin()
	{
		anim.SetInteger("direction", 1);
		Time.timeScale = 1;
		

        if (!Cs.isCreating)
        {
            Cs.StartCreating(startPoint, number);

        }
        EventHandler.TimeScaleChanged(Time.timeScale);
        EventHandler.StartEvent();
    }
}
