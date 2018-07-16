using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using train;
using mapping;

public class OnLineMotion : MonoBehaviour {
    public GameObject line; //GameObject with a LineRendered
    public float speed;
    public Map map;

    private Vertex nextVert;
    private Vertex prevVert;
    private float leftDistance = 0;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        LineRenderer renderer = line.GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
        if (renderer == null)
            Debug.LogWarningFormat("Param [line] for GameObject {0} has no LineRenderer");
        else {   
            Vector3[] positions = new Vector3[renderer.positionCount];
            renderer.GetPositions(positions);
            map = new Map();
            if (positions.Length > 1) {
                //Цикличный путь (пример)
                map.AddVertex(positions[0]);
                for (int i = 1; i < positions.Length; i++) {
                    map.AddVertex(positions[i]);
                    if (i != 3 && i != 2)
                        map[i - 1].addPath(map[i]);
                    //Пример развязки
                    if (i == 4) {
                        map[2] = new Cloverleaf(positions[2], map[1], map[3], map[4]);
                        map[1].addPath(map[2]);
                        map[2].addPath(map[3]);
                    }
                }
                map[map.vertexes.Count - 1].addPath(map[0]);
                //
                this.transform.position = map[0].position;
                nextVert = map[0].nextVert();
                prevVert = map[0];
                NextVertex(nextVert);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (nextVert != null || leftDistance > 0) {
            if (leftDistance <= 0) {
                if (nextVert.hasNext(prevVert)) {
                    Vertex tmp = nextVert;
                    if (nextVert is Cloverleaf)
                        nextVert = (nextVert as Cloverleaf).nextVert(prevVert);
                    else
                        nextVert = nextVert.nextVert(prevVert);
                    prevVert = tmp;
                    if (prevVert is Cloverleaf) {
                        Cloverleaf c = (Cloverleaf)prevVert;
                        Debug.Log(c.nextVert().position);
                        Debug.Log(c.Switch());
                        Debug.Log(c.nextVert().position);
                    }
                    NextVertex(nextVert);
                }
            }
            leftDistance -= Vector3.Magnitude(rb.velocity) * Time.deltaTime;
        } else {
            this.rb.velocity = Vector3.zero;
            GetComponent<Train>().Stop();
        }

	}

    void NextVertex(Vertex vertex) {
        if (vertex == null) {
            this.rb.velocity = Vector3.zero;
            GetComponent<Train>().Stop();
        }
        this.transform.LookAt(vertex.position);
        this.leftDistance = Vector3.Magnitude(vertex.position - this.transform.position);
        rb.velocity = Vector3.ClampMagnitude(vertex.position - this.transform.position, speed);
        if (rb.velocity.magnitude < speed) 
            rb.velocity = rb.velocity * (speed / rb.velocity.magnitude);
    }
}
