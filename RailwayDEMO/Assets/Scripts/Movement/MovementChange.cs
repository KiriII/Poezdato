using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementChange : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
    {
		if (other.GetComponent<WaypointsMovement>() != null)
		{
			Debug.Log("Movement change");
			other.GetComponent<WaypointsMovement>().enabled = false;
			//Destroy(this);
			other.GetComponent<snake>().isMoveing = true;
			other.GetComponent<train.Train>().SetSpeed(50);
		}
	}
}
