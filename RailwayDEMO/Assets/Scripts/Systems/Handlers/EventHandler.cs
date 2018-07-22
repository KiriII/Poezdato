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

    // Creating events
    public delegate void CreatingSystemHandler(bool isCreating);
    public static event CreatingSystemHandler OnCreating;

    // Start events
    public delegate void StartHandler();
    public static event StartHandler OnStart;

    // Tasks events
    public delegate void TaskStateHandler(Task completedTask);
    public static event TaskStateHandler OnTaskCompleted;

    public delegate void LineTaskStateHandler(FullLineTask completedTask);
    public static event LineTaskStateHandler OnFullLineCompleted;

    public delegate void LineGoalHandler(GameObject newTrain);
    public static event LineGoalHandler OnLineChanged;

    public delegate void TaskUIHandler(FullLineTask completedTask);
    public static event TaskUIHandler OnTaskNumberChanged;

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

    public static void StartEvent()
    {
        OnStart?.Invoke();
    }

    public static void TaskCompleted(Task completedTask)
    {
        OnTaskCompleted?.Invoke(completedTask);
    }

    public static void LineTaskCompleted(FullLineTask completedTask)
    {
        OnFullLineCompleted?.Invoke(completedTask);
    }

    public static void LineChanged(GameObject newTrain)
    {
        OnLineChanged?.Invoke(newTrain);
    }

    public static void TaskNumberChanged(FullLineTask completedTask)
    {
        OnTaskNumberChanged?.Invoke(completedTask);
    }
}
