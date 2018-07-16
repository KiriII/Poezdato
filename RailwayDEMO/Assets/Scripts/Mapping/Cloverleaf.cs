using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloverleaf : Vertex {

	// Use this for initialization

    private Vertex _in;
    private Vertex outA;
    private Vertex outB;
    private bool switched = false;

    protected Vertex pathes { get; }

    void Start() {

    }

    public Cloverleaf(Vector3 value, Vertex _in, Vertex outA, Vertex outB) : base(value) {
        this._in = _in;
        this.outA = outA;
        this.outB = outB;
    }

    public bool Switch() {
        switched = !switched;
        return switched;
    }

    public Vertex nextVert(Vertex from) {
        if (from == _in)
            return ((this.switched) ? outB : outA);
        else if (from == outA || from == outB)
            return _in;
        return null;
    }
    public Vertex nextVert() {
        return (this.switched) ? outB : outA;
    }
}
