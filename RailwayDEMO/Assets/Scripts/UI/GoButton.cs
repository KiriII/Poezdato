using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoButton : HideShowUI {

	private CreatingSystem creatingSystem;
	private Button btnGo;

	public override void Setup()
	{
		//base.Setup();
		creatingSystem = FindObjectOfType<CreatingSystem>();
		btnGo = GetComponentInChildren<Button>();
		btnGo.interactable = false;
	}

	void Update () 
	{
        //btnGo.interactable = creatingSystem.lokomotiwExist;
    }

	public override void CheckTimeScale(bool stop)
    {		
    }

	public override void HideOrShow(bool hide)
	{
		base.HideOrShow(hide);
	}
}
