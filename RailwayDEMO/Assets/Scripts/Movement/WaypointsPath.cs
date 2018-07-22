using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsPath : MonoBehaviour {

    public List<GameObject> path;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject != null && other.gameObject.GetComponent<WaypointsMovement>() != null)
            other.gameObject.GetComponent<WaypointsMovement>().AddWaypoints(path);             
    }
}
