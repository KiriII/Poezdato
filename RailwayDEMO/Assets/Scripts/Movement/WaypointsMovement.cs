using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using train;

public class WaypointsMovement : MonoBehaviour {

    public List<GameObject> waypoints;
    public int num = 0;

    public float minDist = 0.1f;
    public float speed = 10f;

    public bool go = true;

    [HideInInspector]
    public bool isReady;


    private const float SPEED_CONST = 0.75f;

	// Use this for initialization
	void Start () {
        speed = GetComponent<Train>().CurrentSpeed;
        if (waypoints.Count != 0)
            isReady = true;

        TrainHandler.OnSpeedChanged += ChangeSpeed;
	}

    private void OnDisable() 
    {
        TrainHandler.OnSpeedChanged -= ChangeSpeed;
    }
	
	// Update is called once per frame
	void Update () {  
        if (waypoints.Count != 0)
        isReady = true;  

        if (go && isReady)
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
		//if (!go)
            //gameObject.transform.position += gameObject.transform.forward * speed * SPEED_CONST * Time.deltaTime;

	}

    public void ChangeSpeed(GameObject train)
    {
        if (train == this.gameObject)
            speed = train.GetComponent<Train>().CurrentSpeed;
    }

    public void Move()
    {
        
        gameObject.transform.LookAt(waypoints[num].transform.position);
        gameObject.transform.position += gameObject.transform.forward * speed * SPEED_CONST * Time.deltaTime;
    }

    public void AddWaypoints(List<GameObject> newPath)
    {
        waypoints.AddRange(newPath);
    }
}
