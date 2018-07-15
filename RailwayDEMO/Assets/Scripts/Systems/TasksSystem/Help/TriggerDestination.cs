﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestination : MonoBehaviour {

    public string triggerID = "0";	

    private void OnTriggerEnter(Collider other)
    {
        EventHandler.TriggerEnter(triggerID);
    }
}
