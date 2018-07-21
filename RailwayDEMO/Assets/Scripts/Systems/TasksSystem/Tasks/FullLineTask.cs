using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullLineTask : Task {

    [Range(1, 5)]
    public int LineNumber;
    public int CargoRequiredNumber;
    public int FuelRequiredNumber;
    public int PlatformRequiredNumber;

    private Dictionary<train.Types, int> requiredTypes = new Dictionary<train.Types, int>();

    private void Awake() 
    {

        // reading from file
        //requiredTypes = HelpFunctions.JsonToDictionary();

        // manually
        requiredTypes.Add(train.Types.Cargo, CargoRequiredNumber);
        requiredTypes.Add(train.Types.Fuel, FuelRequiredNumber);
        requiredTypes.Add(train.Types.Platform, PlatformRequiredNumber);

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
        foreach (var rType in requiredTypes)
        {
            Goals.Add(new TrainSetGoal(this, rType.Key, "Необходимые вагоны", false, 0, rType.Value));
        }       
        
    }

    private void Activating()
    {
        ActivateAllGoals();
    }
}
