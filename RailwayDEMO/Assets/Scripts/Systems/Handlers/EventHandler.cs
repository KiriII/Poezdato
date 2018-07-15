using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour {

    // Time management
	public delegate void TimeScaleHandler(bool isStopped);
    public static event TimeScaleHandler OnTimeScaleChanged;    

    // Trigger collision events
    public delegate void TriggerEnterHandler(string triggerID);
    public static event TriggerEnterHandler OnTriggerEnter;

	public static void TimeScaleChanged(float timeScale)
    {
        OnTimeScaleChanged?.Invoke(timeScale == 0);
    }   

    public static void TriggerEnter(string triggerID)
    {
        if (OnTriggerEnter != null)
            OnTriggerEnter(triggerID);
    }
}
