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

    private void Start()
    {

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
    }

    private void OnEnable()
    {
		// main settings
        Debug.Log("ExampleTask!");
        TaskName = "Составить поезд";
        Description = "Необходимо составить поезд из определенных вагонов";
        // help settings..

		// list of goals
        Goals = new List<Goal>(requiredTypes.Count);
        for (int i = 0; i < requiredTypes.Count; i++)
        {
            Goals.Add(new TrainSetGoal(this, requiredTypes[i], "Необходимые вагоны", false, 0, requiredNumber[i]));
        }       
        
    }

    private void Activating()
    {
        ActivateAllGoals();
    }
}
