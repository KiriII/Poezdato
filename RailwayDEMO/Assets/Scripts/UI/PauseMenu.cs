using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool isPaused = false;
	public GameObject PauseMenuUI;
	public GameObject OptionsMenu;
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			if (!OptionsMenu.activeSelf) 
		{
			{
				if(isPaused) 
				{
					Resume();
				} else 
				{
					Pause();
				}
			}
		}
	}
	
	public void Resume() 
	{
		PauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;
	}
	
	void Pause() 
	{
		EventHandler.TimeScaleChanged(Time.timeScale);
		PauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;
	}
	
	public void loadOptions()
	{
		
	}
	
	public void loadMenu() 
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu");
	}	
}
