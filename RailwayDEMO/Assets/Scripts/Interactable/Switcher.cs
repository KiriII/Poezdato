using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace interactableObj {
	public class Switcher : Interactable {
		private Animator anim;
		public TurnState switcherState;
		
		private void Start() 
		{
			anim = GetComponent<Animator>();
			switcherState = TurnState.RIGHT;
		}

		public override void Interact()
		{
			base.Interact();
			if (switcherState == TurnState.LEFT)
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
			switcherState = TurnState.RIGHT;
		}

		private void TurnLeft()
		{
			anim.SetInteger("direction", -1);
			switcherState = TurnState.LEFT;
		}
	}

	public enum TurnState
	{
		LEFT,
		RIGHT	
	}
}