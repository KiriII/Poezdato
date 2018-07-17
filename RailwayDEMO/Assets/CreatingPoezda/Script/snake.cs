using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour {

    public float speed;
    public List<GameObject> Wagoni = null; // dlya lokomotiva
    public Transform back;

	// Use this for initialization
	void Start () {
        back.transform.position = new Vector3(transform.position.x - transform.localScale.z / 2, transform.position.y , transform.position.z );
	}

    // Update is called once per frame
    void Update() {
        for (int i = 1; i < Wagoni.Count; i++)
        {
            if ((Wagoni[i] != null) && (Wagoni[i - 1] != null))
            {
                Wagoni[i].GetComponent<snake>().speed = speed;
                Wagoni[i].transform.LookAt(Wagoni[i - 1].GetComponent<snake>().back);
            }
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
