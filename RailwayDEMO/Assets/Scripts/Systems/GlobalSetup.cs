using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSetup : MonoBehaviour {

	public Canvas canvas;

	private void Awake() 
	{
		// Initial scene settings
		canvas.renderMode = RenderMode.ScreenSpaceCamera;
		//Cursor.lockState = CursorLockMode.Locked;
	}
}
