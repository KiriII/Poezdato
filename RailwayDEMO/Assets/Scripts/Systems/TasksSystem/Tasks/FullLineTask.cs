using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullLineTask : Task {

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


    private void Start()
    {
        base.AwakeMore();
        // reading from file
        TaskLoader.Instance.LoadTaskInfo(LineNumber);

        // manually
        /*
        requiredTypes.Add(train.Types.Cargo);
        requiredTypes.Add(train.Types.Fuel);
        requiredTypes.Add(train.Types.Platform);

        requiredNumber.Add(CargoRequiredNumber);
        requiredNumber.Add(FuelRequiredNumber);
        requiredNumber.Add(PlatformRequiredNumber);
        Debug.Log("Init");
        */
        EventHandler.OnStart += Activating;


        // main settings
        TaskName = "Составить поезд";
        Description = "Необходимо составить поезд из определенных вагонов";
        // help settings..

        // list of goals
        currentNumber = 0;
        failed = false;
        Goals = new List<Goal>(requiredTypes.Count);
        for (int i = 0; i < requiredTypes.Count; i++)
        {
            Goals.Add(new TrainSetGoal(this, requiredTypes[i], "Необходимые вагоны", false, 0, requiredNumber[i]));
            maxNumber += requiredNumber[i];
        }
        
        //Activating();
    }

    public override void AwakeMore()
    {
        
    }

    private void OnEnable()
    {
		
    }

    public void Activating()
    {
        currentNumber = 0;
        failed = false;
        ActivateAllGoals();
    }

    public override void Done()  // OnComplete actions
    {
        base.Done();
        EventHandler.LineTaskCompleted(this);        
    }
}
