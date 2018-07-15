using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {

	public GameObject loadingPanel;
	public Slider slider;
	public Text sliderText;

	public void LoadLevel(int index) {
		StartCoroutine(LoadAsynchronously(index));
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
}
