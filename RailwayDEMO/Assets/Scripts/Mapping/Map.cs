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