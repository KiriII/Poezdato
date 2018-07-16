using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mapping {
    public class Map {

        public List<Vertex> vertexes;

        public Vertex this[int key] { 
            get {
                return vertexes[key];
            }
            set {
                vertexes[key] = value;
            }
        }

        public Map() {
            vertexes = new List<Vertex>(); 
        }

        public Map(ICollection<Vector3> c) { 
            vertexes = new List<Vertex>();
            foreach (Vector3 v in c)
                vertexes.Add(new Vertex(v));
        }

        public Map(Vector3[] c) {
            vertexes = new List<Vertex>();
            foreach (Vector3 v in c)
                vertexes.Add(new Vertex(v));
        }

        public void AddVertex(Vector3 v) {
            this.vertexes.Add(new Vertex(v));
        }

        public class Vertex {
            public Vector3 position { set { } get { return pos; } }
            private Vector3 pos;
            protected List<Path> pathes;
            public bool stop = false;

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
        public class Cloverleaf : Vertex {
            private Vertex _in;
            private Vertex outA;
            private Vertex outB;
            private bool switched = false;

            protected Vertex pathes { get; }

            public Cloverleaf(Vector3 value, Vertex _in, Vertex outA, Vertex outB)
                : base(value) {
                this._in = _in;
                this.outA = outA;
                this.outB = outB;
            }

            public bool Switch() {
                switched = !switched;
                return switched;
            }

            public void addPath(Vertex to, float weight) { }

            public Vertex nextVert(Vertex from) {
                if (from == _in)
                    return (this.switched) ? outB : outA;
                else if (from == outA || from == outB)
                    return _in;
                return null;
            }
            public Vertex nextVert() {
                return (this.switched) ? outB : outA;
            }
        }
        public class Path {
            public Vertex from;
            public Vertex to;
            public float weight;

            public Path(Vertex from, Vertex to) {
                this.from = from;
                this.to = to;
                this.weight = Vector3.Magnitude(from.position - to.position);
            }
        }
    }
}