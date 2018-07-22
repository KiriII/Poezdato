using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace interactableObj {
	public class Switcher : Interactable {

        public List<GameObject> path1;
        public List<GameObject> path2;

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

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<WaypointsMovement>() != null)
            {
                if (switcherState == TurnState.LEFT)
                {

                    other.gameObject.GetComponent<WaypointsMovement>().AddWaypoints(path2);
                }
                else
                {
                    other.gameObject.GetComponent<WaypointsMovement>().AddWaypoints(path1);
                }
            }
        }
    }	

	public enum TurnState
	{
		LEFT,
		RIGHT	
	}
}