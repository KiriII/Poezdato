using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal  {

    public Task Task { get; set; }              // task with this goal
    public string Description { get; set; }     // description of the goal
    public bool Completed { get; set; }         // state
    public int CurrentAmount { get; set; }      // number of completed iterations
    public int RequiredAmount { get; set; }     // number of required iterations

    private bool initialized = false;           // init check
    public bool Initialized
    {
        get
        {
            return initialized;
        }
        private set
        {
            initialized = value;
        }
    }

    public virtual void Init()
    {
        Initialized = true;
        CurrentAmount = 0;
        Completed = false;
        // default initialize stuff
    }

    public void Evaluate()   // completion check
    {
        if (CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    public virtual void Complete()  // OnComplete actions
    {
        Completed = true;

        Task.CheckGoals();        
        //Debug.Log("Goal marked as completed.");
    }
}
