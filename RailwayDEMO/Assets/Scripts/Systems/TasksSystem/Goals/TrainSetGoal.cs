using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using train;

public class TrainSetGoal : Goal {

	public train.Types requiredTrainType { get; set; }

    private int workingLine;

	public TrainSetGoal(FullLineTask task, train.Types trainType, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Task = task;
        this.workingLine = task.LineNumber;
        this.requiredTrainType = trainType;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

	public override void Init()
    {
        base.Init();
        //EventHandler+
    }

	public void CarriageCheck(GameObject arrivedCarriage)
	{
        Train arrivedTrain = arrivedCarriage.GetComponent<Train>(); 
		if (workingLine == arrivedTrain.CurrentLine && arrivedTrain.type == requiredTrainType)
		{
			this.CurrentAmount++;
            Evaluate();
		}
	}

	 public override void Complete()
    {
        base.Complete();
         //EventHandler-
    }
}
