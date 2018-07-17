using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestination : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        EventHandler.TriggerEnter();
    }
}
