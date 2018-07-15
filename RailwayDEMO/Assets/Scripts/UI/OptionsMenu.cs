using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
	public AudioMixer audioMixer;
	public Dropdown resolDropdown;

	Resolution[] resolutions;
	
void Start() {
	resolutions = Screen.resolutions;
	resolDropdown.ClearOptions();
	
	List<string> options = new List<string>();
	
	int currentResolutionIndex = 0;
	
	for (int i = 0; i<resolutions.Length; i++) 
	{
		string option = resolutions[i].width + " x " + resolutions[i].height;
		options.Add(option);
		
		if (resolutions[i].width == Screen.currentResolution.width && 
		resolutions[i].height == Screen.currentResolution.height) 
		{
			currentResolutionIndex = i;
		}
			
	}
	
	resolDropdown.AddOptions(options);
	resolDropdown.value = currentResolutionIndex;
	resolDropdown.RefreshShownValue();
	
}

public void FullscreenMode(bool isFullscreen) {
	Screen.fullScreen = isFullscreen;
	}


public void SetResolution(int resolutionIndex) {
	Resolution resolution = resolutions[resolutionIndex];
	Screen.SetResolution(resolution.width , resolution.height , Screen.fullScreen);
}

public void SetQuality(int qualityIndex) {
	QualitySettings.SetQualityLevel(qualityIndex);
	}
	
public void SetVolume(float volume) {
	audioMixer.SetFloat("volume" , volume);
	}
	

}