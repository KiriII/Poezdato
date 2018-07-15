using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : Interactable {
	private Animator anim;
	private State switcherState;

    private void Start() 
    {
        anim = GetComponent<Animator>();
		switcherState = State.LEFT;
    }

	public override void Interact()
    {
        base.Interact();
		if (switcherState == State.LEFT)
		{
			TurnRight();
		}       		
		else 
		{			
			TurnLeft();
		}
		// 			
    }

	private void TurnRight()
	{		
		anim.SetInteger("direction", 1);
		switcherState = State.RIGHT;
	}

	private void TurnLeft()
	{
		anim.SetInteger("direction", -1);
		switcherState = State.LEFT;
	}
}

enum State
{
	LEFT,
	RIGHT	
}
