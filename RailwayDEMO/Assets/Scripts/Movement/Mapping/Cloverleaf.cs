using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using interactableObj;

public class Cloverleaf : Vertex {
	// Use this for initialization

    public Vertex _in;
    public Vertex outA;
    public Vertex outB;
    public Vector3[] pathA;
    public Vector3[] pathB;
    private bool switched = false;

    public Switcher Switcher;

    protected Vertex pathes { get; }
    void Start() {
        for (int i = 0; i < pathA.Length; i++)
            pathA[i] = this.transform.position + pathA[i];
        for (int i = 0; i < pathB.Length; i++)
            pathB[i] = this.transform.position + pathB[i];
    }

    public bool Switch() {
        switched = !switched;
        return switched;
    }

    public bool isSwitched() {
        return (Switcher != null) ? (Switcher.switcherState == TurnState.LEFT) : switched;
    }

    public Vector3[] getMovePoints(Vertex from) {       
        if (from.gameObject == _in.gameObject)
            return ((this.isSwitched()) ? pathB : pathB);
        else if (from.gameObject == outA.gameObject)
            return Reversed(pathA);
        else if (from.gameObject == outB.gameObject)
            return Reversed(pathB);
        else 
            return new Vector3[0];
    }

    public Vertex nextVert(Vertex from) {
        if (from.gameObject == _in.gameObject)
            return ((this.isSwitched()) ? outB : outA);
        else if (from.gameObject == outA.gameObject || from.gameObject == outB.gameObject)
            return _in;
        return null;
    }
    public Vertex nextVert() {
        return (this.isSwitched()) ? outB : outA;
    }

}
