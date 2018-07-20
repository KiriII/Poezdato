using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using train;

namespace interactableObj {
	public class TrafficLight : Interactable {

		[Header("Lights")]
		public Light greenLight;
		public Light redLight;

		public LightState currentLight;

		private Train stoppedTrain;

		private void Start() 
		{
			SetGreenLight();
		}

		public override void IsStopped(bool stop)
		{
			base.IsStopped(stop);
			isStopped = stop; 
		}

		public override void Interact()
		{
			if (!isStopped) {
				base.Interact();

				if (currentLight == LightState.GREEN)
				{
					SetRedLight();
				}       		
				else 
				{			
					SetGreenLight();
				}
				//
			}
		}

		private void SetRedLight()
		{
			greenLight.enabled = false;
			redLight.enabled = true;			
			currentLight = LightState.RED;
		}

		private void SetGreenLight()
		{
			redLight.enabled = false;
			greenLight.enabled = true;		
			currentLight = LightState.GREEN;
			if (stoppedTrain != null)
				stoppedTrain.Departure();			
		}	

		private void OnTriggerEnter(Collider other)
   		{
			if (currentLight == LightState.RED)
			{
       			stoppedTrain = other.GetComponentInChildren<Train>();
				if (stoppedTrain != null && stoppedTrain.type == train.Types.MainTrain)
					stoppedTrain.Stop();
			}
    	}
	}

	public enum LightState
	{
		GREEN,
		RED	
	}
}
