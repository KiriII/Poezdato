using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	
	public GameObject loadingPanel;
	public Slider slider;
	public Text sliderText;

	public void LoadLevel() {
		StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex + 1));
	}

	IEnumerator LoadAsynchronously (int index) {
		AsyncOperation operation = SceneManager.LoadSceneAsync(index);

		loadingPanel.SetActive(true);

		while(!operation.isDone) {
			float progress = Mathf.Clamp01(operation.progress / .9f);

			slider.value = progress;
			sliderText.text = progress * 100f + "%";
			yield return null;

		}

	}
	
	public void QuitGame() {
		Application.Quit();
	}
		
}
