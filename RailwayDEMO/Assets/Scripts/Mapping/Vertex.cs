using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mapping;

public class Vertex : MonoBehaviour {

	// Use this for initialization
	void Start () {
		 
	}
    public Vector3 position { set { } get { return pos; } }
    private Vector3 pos;
    protected List<Path> pathes;
    public bool stop {
        get {
            return stop;
        }
        set {
            stop = value;
        }
    }

    public Vertex(Vector3 position) {
        pathes = new List<Path>();
        this.pos = position;
    }

    public void addPath(Vertex to) {
        this.pathes.Add(new Path(this, to));
        to.pathes.Add(new Path(to, this));
    }

    public Vertex nextVert(Vertex from) {
        return pathes.Find(p => (p.to != from)).to;
    }
    public Vertex nextVert() {
        return pathes.Find(p => p.from == this).to;
    }

    public bool hasNext(Vertex from) {
        return nextVert(from) != null;
    }
    public bool hasNext() {
        return nextVert() != null;
    }
}
