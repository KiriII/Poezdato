using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace interactableObj {
	public class TrafficLight : Interactable {

		[Header("Lights")]
		public Light greenLight;
		public Light redLight;

		private LightState currentLight;

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
	}

	enum LightState
	{
		GREEN,
		RED	
	}
}
