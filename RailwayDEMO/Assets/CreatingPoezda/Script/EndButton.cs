using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndButton : MonoBehaviour {

    public CreatingSystem creatingSystem;
    public Text text;

	// Use this for initialization
	void Start () {
        creatingSystem = FindObjectOfType<CreatingSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Button>().interactable = creatingSystem.lokomotiwExist;
        this.gameObject.GetComponent<Image>().enabled = creatingSystem.cameraMove.createPoezd;
        text.enabled = creatingSystem.cameraMove.createPoezd;
    }
}
