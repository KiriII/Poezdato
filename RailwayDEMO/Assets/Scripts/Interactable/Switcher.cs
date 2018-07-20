using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace interactableObj {
	public class Switcher : Interactable {
		private Animator anim;
		[HideInInspector]
		public TurnState switcherState;
		
		private void Start() 
		{
			anim = GetComponent<Animator>();
			switcherState = TurnState.LEFT;
		}

		public override void IsStopped(bool stop)
		{
			base.IsStopped(stop);
			isStopped = stop; 
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

		private void TurnLeft()
		{		
			anim.SetInteger("direction", -1);
			switcherState = TurnState.LEFT;
		}

		private void TurnRight()
		{
			anim.SetInteger("direction", 1);
			switcherState = TurnState.RIGHT;
		}
	}	

	public enum TurnState
	{
		LEFT,
		RIGHT	
	}
}