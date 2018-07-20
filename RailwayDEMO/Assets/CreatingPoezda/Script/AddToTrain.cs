using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToTrain : MonoBehaviour {

    private CreatingSystem Cs;
    public snake lokomotiw;
    Transform it;

    // Use this for initialization
    void Start () {
        Cs = FindObjectOfType<CreatingSystem>();
        it = this.gameObject.transform;
        it.position = new Vector3(it.position.x - Cs.range/1.5f - Cs.width/2 , it.position.y , it.position.z);
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Jop");
        if (other.tag == "Wagonchik")
        {
            lokomotiw.Wagoni.Add(other.gameObject);
            lokomotiw.InitArrays();
            it.position = new Vector3(it.position.x - Cs.range - Cs.width, it.position.y, it.position.z);
            other.gameObject.GetComponent<snake>().speed = 0; ;
        }
    }
}
