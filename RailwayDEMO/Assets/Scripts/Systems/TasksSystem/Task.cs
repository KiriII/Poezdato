using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Task : MonoBehaviour {

    public List<Goal> Goals { get; set; }
    public string QuestName { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int GoalIndex { get; set; } 

    private void Start()
    {
        Goals = new List<Goal>();
        GoalIndex = 0;
    }

    public void CheckGoals()
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
        Goals.ForEach(g => g.Init());
    }

    public virtual void Done()
    {			
        TaskSystem.Instance.CheckTasks();
		
        // Task result
    }
}
