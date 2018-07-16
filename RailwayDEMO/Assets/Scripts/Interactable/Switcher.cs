using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace interactableObj {
	public class Switcher : Interactable {
		private Animator anim;
		private TurnState switcherState;

		private void Start() 
		{
			anim = GetComponent<Animator>();
			switcherState = TurnState.LEFT;
		}

		public override void Interact()
		{
			if (!isStopped) {
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

	enum TurnState
	{
		LEFT,
		RIGHT	
	}
}