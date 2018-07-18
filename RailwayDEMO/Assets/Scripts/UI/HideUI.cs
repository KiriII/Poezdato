using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideUI : MonoBehaviour {

    private CreatingSystem creatingSystem;
    public Text[] text;
    public bool forCreating;

	// Use this for initialization
	void Start () {
        creatingSystem = FindObjectOfType<CreatingSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.GetComponent<Button>()) this.gameObject.GetComponent<Button>().interactable = creatingSystem.lokomotiwExist;
        this.gameObject.GetComponent<Image>().enabled = creatingSystem.cameraMove.createPoezd == forCreating;
        for (int i = 0; i < text.Length; i++)
        {
            text[i].enabled = creatingSystem.cameraMove.createPoezd == forCreating;
        }
    }
}
