using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using interactableObj;

public class Vertex : MonoBehaviour {

	// Use this for initialization

    public Vector3[] positionArr;
    public TrafficLight TrafficLight;
    public Vertex from;
    public Vertex to;


    void Start () {
        for (int i = 0; i < positionArr.Length; i++)
            positionArr[i] = this.transform.position + positionArr[i];
	}

    public Vertex nextVert(Vertex from) {
        if (from == null)
            return nextVert();
        return (this.from != null && from.gameObject == this.from.gameObject) ? this.to : this.from; //
    }
    public Vertex nextVert() {
        return (to == null) ? from : to; //
    }

    public bool hasNext(Vertex from) {
        return nextVert(from) != null;
    }
    public bool hasNext() {
        return nextVert() != null;
    }

    public Vector3[] getMovePoints(Vertex from) {
        if (from == null || from.gameObject == this.from.gameObject)
            return positionArr;
        return Reversed(positionArr);
    }

    public bool isStopLight() {
        return (this.TrafficLight != null) ? this.TrafficLight.currentLight == LightState.RED : false;
    }
    protected Vector3[] Reversed(Vector3[] arr) {
        Vector3[] newArr = new Vector3[arr.Length];
        for (int i = 0; i < arr.Length; i++) {
            newArr[i] = arr[(arr.Length - 1) - i];
        }
        return newArr;
    }
}
