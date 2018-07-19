using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using train;

public class Barrier : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		other.GetComponentInChildren<Train>().Arrival();
	}
}
