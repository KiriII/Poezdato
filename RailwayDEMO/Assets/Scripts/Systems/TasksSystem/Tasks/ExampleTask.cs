using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleTask : Task {

	public GameObject goalPosition;

    private void OnEnable()
    {
		// main settings
        Debug.Log("ExampleTask!");
        TaskName = "ExampleTask";
        Description = "Try to understand example task";
        // help settings..

		// list of goals
        Goals = new List<Goal>
        {
            // create goal -> add to quest list of goals
        };
        GoalIndex = 0;
        ActivateGoal(0);
    }
}
