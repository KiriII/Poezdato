using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour {

    // Time management
	public delegate void TimeScaleHandler(bool isStopped);
    public static event TimeScaleHandler OnTimeScaleChanged;    

    // Trigger collision events
    public delegate void TriggerEnterHandler();
    public static event TriggerEnterHandler OnTriggerEnter;

    // Trigger collision events
    public delegate void CreatingSystemHandler(bool isCreating);
    public static event CreatingSystemHandler OnCreating;

	public static void TimeScaleChanged(float timeScale)
    {
        OnTimeScaleChanged?.Invoke(timeScale == 0);
    }   

    public static void TriggerEnter()
    {
        OnTriggerEnter?.Invoke();
    }

    public static void CreatingChanged(bool isCreating)
    {
        OnCreating?.Invoke(isCreating);
    }   
}
