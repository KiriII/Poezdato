using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLineMotion : MonoBehaviour {
    public GameObject line; //GameObject with a LineRendered
    public float speed;
    public bool Loop;
    private Vector3[] positions;

    private int nextVert = 1;
    private float leftDistance = 0;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        LineRenderer renderer = line.GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
        if (renderer == null)
            Debug.LogWarningFormat("Param [line] for GameObject {0} has no LineRenderer");
        else {
            positions = new Vector3[renderer.positionCount];
            renderer.GetPositions(positions);
            if (positions.Length > 1) {
                this.transform.position = positions[0];
                NextVertex(positions[nextVert]);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if ((nextVert < positions.Length - 1 || leftDistance > 0) || Loop) {
            if (leftDistance <= 0) {
                nextVert = (Loop) ? (++nextVert % positions.Length) : ++nextVert;
                NextVertex(positions[nextVert]);
                Debug.LogFormat("{0}/{1}", nextVert, positions.Length);
            }
            leftDistance -= Vector3.Magnitude(rb.velocity) * Time.deltaTime;
        } else
            this.rb.velocity = Vector3.zero;
	}

    void NextVertex(Vector3 vertex) {
        this.transform.LookAt(vertex);
        this.leftDistance = Vector3.Magnitude(vertex - this.transform.position);
        rb.velocity = Vector3.ClampMagnitude(vertex - this.transform.position, speed);
    }
}
