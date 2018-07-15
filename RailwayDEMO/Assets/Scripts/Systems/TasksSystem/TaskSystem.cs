using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TaskSystem : MonoBehaviour {

	#region Singleton
    public static TaskSystem Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Task system unexpected error");
            return;
        }
        Instance = this;
    }
    #endregion
	
	[HideInInspector]
    public List<Task> Tasks { get; set; }   // List of tasks to complete
	[HideInInspector]
    public bool AllCompleted { get; set; }  // state
	
    [HideInInspector]
    public Task currentTask;                // current active task
	[Tooltip("Text field for task description")]
	public Text currentTaskText;            // UI text for current active tasks
	
	
    private void Start()
    {       
		Tasks = GetComponents<Task>().ToList(); // List of available tasks
		TurnOffAllTasks();
        ActivateTask(0);			            // first task activation
    }

    public void ActivateTask(int index)
    {
        currentTask = Tasks[index];

        currentTask.enabled = true;
        //currentTaskText.text += "\n" + currentTask.Description;
        
    }

	private void TurnOnOffAllTasks(bool enabled)
	{
		foreach (var task in Tasks)
		{
			task.enabled = enabled;
		}
	}

	public void TurnOnAllTasks()
	{
		TurnOnOffAllTasks(true);
	}

	public void TurnOffAllTasks()
	{
		TurnOnOffAllTasks(false);
	}

    public void CheckTasks()    // completion check
    {
        AllCompleted = Tasks.All(g => g.Completed);
        if (AllCompleted)
        {
            Done();
        }
    }

    private void Done()         // OnComplete actions
    {
        // Result
        currentTaskText.text = "All tasks are done!";
        Debug.Log("All tasks are done!");
    }
}
