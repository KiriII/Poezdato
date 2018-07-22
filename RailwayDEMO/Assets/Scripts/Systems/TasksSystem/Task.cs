using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Task : MonoBehaviour {

    [Tooltip("Connect this task with task system")]
    public bool taskSystem = false;

    public List<Goal> Goals { get; set; }       // List of goals to complete
    public string TaskName { get; set; }        // Task name
    public string Description { get; set; }     // Task description
    public bool Completed { get; set; }         // state
    public int GoalIndex { get; set; }          // Index of current goal

    private void Awake()
    {
        Goals = new List<Goal>();   // list init
        GoalIndex = 0;              // first goal index

        AwakeMore();
    }

    public virtual void AwakeMore()
    {

    }

    public void CheckGoals()        // completion check
    {        
        Completed = Goals.All(g => g.Completed);
        if (Completed)
        {
            Done();
        }       
    }

    public void ActivateNextGoal()
    {
        GoalIndex++;
        if (GoalIndex < Goals.Count)
            Goals[GoalIndex].Init();
    }

    public void ActivateGoal(int index)
    {
        if (index >= 0 && index < Goals.Count)
            if (!Goals[index].Initialized)
                Goals[index].Init();

    }

    public void ActivateAllGoals()
    {
        Debug.Log("Activating " + Goals.Count + "goals");
        Goals.ForEach(g => g.Init());
    }

    public virtual void Done()  // OnComplete actions
    {
        Debug.Log("Task comleted");
        EventHandler.TaskCompleted(this);	
        if (taskSystem) TaskSystem.Instance.CheckTasks();
		
        // Task result
    }
}
