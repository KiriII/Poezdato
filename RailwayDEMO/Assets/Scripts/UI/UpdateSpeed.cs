using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using train;

public class UpdateSpeed : MonoBehaviour {
	
	private Text text;
	private string[] commonText = new string[2];
	private GameObject trackedTrain;
	private Train trackedTrainInfo;

	
	void Start () 
	{
		commonText[0] = " speed: ";
		commonText[1] = " km/h";
		text = GetComponentInChildren<Text>();
		
		TrainHandler.OnSpeedChanged += UpdateTrainSpeed;
		TrainHandler.OnStateChanged += UpdateTrainSpeed;
		TrainHandler.OnInfoUpdate += SetTrackedTrain;
	}
	
	private void OnDisable() 
	{
		TrainHandler.OnSpeedChanged -= UpdateTrainSpeed;
		TrainHandler.OnStateChanged -= UpdateTrainSpeed;
		TrainHandler.OnInfoUpdate -= SetTrackedTrain;
	}

	public void SetTrackedTrain(GameObject newTracking)
	{
		trackedTrain = newTracking;
		if (trackedTrainInfo != null)
			trackedTrainInfo.SetTracked(false);
		trackedTrainInfo = trackedTrain.GetComponent<Train>();
		trackedTrainInfo.SetTracked(true);
		UpdateTrainSpeed(trackedTrain);
	}

	private void UpdateTrainSpeed(GameObject currentTrain)
	{
		if (trackedTrain != currentTrain) return;
		text.text = trackedTrainInfo.Name + commonText[0] + trackedTrainInfo.CurrentSpeed.ToString() + commonText[1];
	}
}
