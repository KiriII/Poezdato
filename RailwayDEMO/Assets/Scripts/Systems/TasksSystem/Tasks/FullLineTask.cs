using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using train;

public class FullLineTask : MonoBehaviour {
        
    public string TaskName { get; set; }        // Task name
    public string Description { get; set; }     // Task description
    public bool Completed { get; set; }         // state


    [Range(1, 5)]   
    public int LineNumber = 1;
    [Header("Only in manual mode")]
    public int CargoRequiredNumber;
    public int FuelRequiredNumber;
    public int PlatformRequiredNumber;

    //[HideInInspector]
    public List<train.Types> requiredTypes = new List<train.Types>();
    //[HideInInspector]
    public List<int> requiredNumber = new List<int>();
    //[HideInInspector]
    public int maxNumber;
    //[HideInInspector]
    public int currentNumber;
    //[HideInInspector]
    public bool failed;

    public int numCompleted;

    public bool isFinished;

    private void Awake()
    {
        EventHandler.OnStart += Activating;
        EventHandler.OnLineChanged += Calc;
        TaskName = "Составить поезд";
        Description = "Необходимо составить поезд из определенных вагонов";
    }

    public void Activating()
    {
        // reading from file
        TaskLoader.Instance.LoadTaskInfo(LineNumber);
        
        Completed = false;
        currentNumber = 0;
        numCompleted = 5;
        failed = false;
        isFinished = false;
        foreach (var v in requiredNumber)
        {
            maxNumber += v;
            if (v == 0) numCompleted--;
        }
        ResetTask();        
    }

    public void ResetTask()
    {
        requiredTypes.Clear();
        requiredNumber.Clear();
        TaskLoader.Instance.LoadTaskInfo(LineNumber);
        Completed = false;
        currentNumber = 0;
        numCompleted = 5;
        failed = false;
        isFinished = false;

        foreach (var v in requiredNumber)
        {
            if (v == 0) numCompleted--;
        }

    }

    public void Calc(GameObject arrivedCarriage)
    {
        Train arrivedTrain = arrivedCarriage.GetComponent<Train>();
        if (LineNumber == arrivedTrain.CurrentLine)
        {
            currentNumber++;
            if (arrivedTrain.type == train.Types.MainTrain)
            {
                requiredNumber[0] -= 1;
                if (requiredNumber[0] == 0)  numCompleted--;
            }
            if (arrivedTrain.type == train.Types.Cargo)
            {
                requiredNumber[1] -= 1;
                if (requiredNumber[1] == 0) numCompleted--;
            }
            if (arrivedTrain.type == train.Types.Fuel)
            {
                requiredNumber[2] -= 1;
                if (requiredNumber[2] == 0) numCompleted--;
            }
            if (arrivedTrain.type == train.Types.Platform)
            {
                requiredNumber[3] -= 1;
                if (requiredNumber[3] == 0) numCompleted--;
            }
            if (arrivedTrain.type == train.Types.Platform)
            {
                requiredNumber[4] -= 1;
                if (requiredNumber[4] == 0) numCompleted--;
            }
            if (numCompleted == 0)
            {
                Debug.Log("Comleted!");
                Completed = true;
                isFinished = true;
                EventHandler.LineTaskCompleted(this);
            }
            if (currentNumber >= maxNumber)
            {
                Debug.Log("failed");
                Completed = false;
                isFinished = true;
                //failed = true;
                EventHandler.LineTaskCompleted(this);
            }
        }
        if (isFinished)
            EventHandler.LineTaskCompleted(this);
    }

    public void Done()  // OnComplete actions
    {
        Debug.Log("Task comleted");
        EventHandler.LineTaskCompleted(this);
        //EventHandler.OnLineChanged -= Calc;
    }

    public void Failed()  // OnComplete actions
    {
        Debug.Log("Task faild");
        EventHandler.LineTaskCompleted(this);
        //EventHandler.OnLineChanged -= Calc;
    }
}
