using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsMovement : MonoBehaviour {

    public List<GameObject> waypoints;
    public int num = 0;

    public float minDist = 0.1f;
    public float speed = 10f;

    public bool go = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {    

        if (go)
        {
            float dist = Vector3.Distance(gameObject.transform.position, waypoints[num].transform.position);
            if (dist > minDist)
            {
                Move();
            }
            else
            {
                num++;
                if (num > waypoints.Count - 1)
                    go = false;
            }
        }
		
	}

    public void Move()
    {
        gameObject.transform.LookAt(waypoints[num].transform.position);
        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
    }

    public void AddWaypoints(List<GameObject> newPath)
    {
        waypoints.AddRange(newPath);
    }
}
