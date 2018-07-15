using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleTask : Task {

	public GameObject goalPosition;

    private void OnEnable()
    {
		// main settings
        Debug.Log("ExampleTask!");
        QuestName = "ExampleTask";
        Description = "Try to understand example task";
        // help settings..

		// list of goals
        Goals = new List<Goal>
        {
            new DestinationGoal(this, goalPosition.GetComponent<TriggerDestination>().triggerID, "reach destination", false, 0, 1),
            // create goal -> add to quest list of goals
        };
        GoalIndex = 0;
        ActivateGoal(0);
    }
}
