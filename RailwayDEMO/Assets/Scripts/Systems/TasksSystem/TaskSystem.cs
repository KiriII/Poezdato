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
    public List<Task> Tasks { get; set; }
	[HideInInspector]
    public bool AllCompleted { get; set; }
	
    [HideInInspector]
    public Task currentTask;
	[Tooltip("Text field for task description")]
	public Text currentTaskText;
	
	
    private void Start()
    {       
		Tasks = GetComponents<Task>().ToList();
		TurnOffAllTasks();
        ActivateTask(0);			
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

    public void CheckTasks()
    {
        AllCompleted = Tasks.All(g => g.Completed);
        if (AllCompleted)
        {
            Done();
        }
    }

    private void Done()
    {
        // Result
        currentTaskText.text = "All tasks are done!";
        Debug.Log("All tasks are done!");
    }
}
