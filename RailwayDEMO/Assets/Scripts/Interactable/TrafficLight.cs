using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace interactableObj {
	public class TrafficLight : Interactable {

		[Header("Lights")]
		public Light greenLight;
		public Light redLight;

		public LightState currentLight;

		private void Start() 
		{
			SetGreenLight();
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
					TrainHandler.Departure();
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
		}	

		private void OnTriggerEnter(Collider other)
   		{
			if (currentLight == LightState.RED)
       			EventHandler.TriggerEnter();
    	}
	}

	public enum LightState
	{
		GREEN,
		RED	
	}
}
