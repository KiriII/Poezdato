using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using train;

public class TrainSetGoal : Goal {

	public train.Types requiredTrainType { get; set; }

    private int workingLine;
    private int maxNumber;
    private FullLineTask fullLineTask;

    public TrainSetGoal(FullLineTask task, train.Types trainType, string description, bool completed, int currentAmount, int requiredAmount)
    {
        //this.Task = task;        
        this.workingLine = task.LineNumber;
        this.requiredTrainType = trainType;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
        
        fullLineTask = task;        
    }

	public override void Init()
    {
        base.Init();
        maxNumber = fullLineTask.maxNumber;   
        Evaluate();
        EventHandler.OnLineChanged += CarriageCheck;
    }

	public void CarriageCheck(GameObject arrivedCarriage)
	{
        Train arrivedTrain = arrivedCarriage.GetComponent<Train>();
        //Debug.Log("workingLine = " + workingLine + "\tCurrentLine = " + arrivedTrain.CurrentLine);
        if (workingLine == arrivedTrain.CurrentLine)
        {
            if (arrivedTrain.type == requiredTrainType)
            {                
                this.CurrentAmount++;
                Debug.Log(arrivedTrain.type.ToString() + " current = " + CurrentAmount + " req = " + RequiredAmount);
                Evaluate();
            }
            //Debug.Log("Current n = " + fullLineTask.currentNumber + "max = " + fullLineTask.maxNumber);
            if (fullLineTask.currentNumber >= fullLineTask.maxNumber)
            {
                if (!fullLineTask.failed && !fullLineTask.Completed)
                {
                    Debug.Log("failed");
                    fullLineTask.failed = true;
                    EventHandler.LineTaskCompleted(fullLineTask);
                    //EventHandler.OnLineChanged -= CarriageCheck;
                }
            }
        }
	}

	public override void Complete()
    {
        base.Complete();
        EventHandler.OnLineChanged -= CarriageCheck;
    }
}
