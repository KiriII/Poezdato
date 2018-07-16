using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float moveSpeed;
    public float rotSpeed;
    public int place = 0;
    private float pitch = 0;
    private float yaw = 0;
    public bool createPoezd;
    public Transform[] cameraPlaces = new Transform[5];
    public Transform[] createPlaces = new Transform[3];

	// Use this for initialization
	void Start () {
        place = -1; // sozdanie poezda v nachale
        transform.rotation = createPlaces[0].rotation;
        transform.position = createPlaces[0].position;
        createPoezd = true;
        cameraPlaces[cameraPlaces.Length - 1] = null; // free camera
	}
	
	// Update is called once per frame
	void Update () {
        float inpX = Input.GetAxis("Horizontal");
        float inpY = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.F1) && (!createPoezd)) place = 0;
        if (Input.GetKeyDown(KeyCode.F2) && (cameraPlaces[0] != null) && (!createPoezd))
        {
            place = 1;
        }
        if (Input.GetKey(KeyCode.F3) && (cameraPlaces[1] != null) && (!createPoezd))
        {
            place = 2;
        }
        if (Input.GetKey(KeyCode.F4) && (cameraPlaces[2] != null) && (!createPoezd))
        {
            place = 3;
        }
        if (Input.GetKey(KeyCode.F5) && (cameraPlaces[3] != null) && (!createPoezd))       
        {
            place = 4;
        }
            if ((place == 0) && (!createPoezd))
        {
            transform.position += inpY * transform.forward * moveSpeed * Time.deltaTime;
            transform.position += inpX * transform.right * moveSpeed * Time.deltaTime;
        }
        else
        {
            if (!createPoezd) gameObject.transform.position = cameraPlaces[place - 1].position;
           
        }
        if (!createPoezd)
        {
            yaw += rotSpeed * Input.GetAxis("Mouse X");
            if ((pitch <= 90) && (pitch >= -90)) pitch -= rotSpeed * Input.GetAxis("Mouse Y");
            else if (pitch < 0) pitch = -90;
            else pitch = 90;
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
        else transform.position += inpX * transform.right * moveSpeed * Time.deltaTime;
    }

    public void StartCreating(int createPoint) //  массив уже задан
    {
        createPoezd = true;
        place = -1;
        transform.rotation = createPlaces[createPoint].rotation;
        transform.position = createPlaces[createPoint].position;
    }

}
