using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TaskLoader : MonoBehaviour {

    #region Singleton

    public static TaskLoader Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Task loader error");
            return;
        }
        Instance = this;

        AwakeMore();
    }

    #endregion 

    [HideInInspector]
    public TaskInfo taskInfo = new TaskInfo();
    private string path;

    [HideInInspector]
    public FullLineTask[] tasks;
    

    private void AwakeMore()
    {
        path = Path.Combine(Application.dataPath, "TaskInfo.json");

        if (File.Exists(path))
        {
            taskInfo = JsonUtility.FromJson<TaskInfo>(File.ReadAllText(path));            
        }
        else
        {
            Debug.Log("There's no tasks!");
        }
        tasks = GetComponents<FullLineTask>();
    }

    public void LoadAllTasksInfo()
    {        
        //-----Line 1-----
        tasks[0].requiredTypes.AddRange(ListConvertStringToTypes(taskInfo.Line1Types));
        tasks[0].requiredNumber.AddRange(taskInfo.Line1Number);
        //-----Line 2-----
        tasks[1].requiredTypes.AddRange(ListConvertStringToTypes(taskInfo.Line2Types));
        tasks[1].requiredNumber.AddRange(taskInfo.Line2Number);
        //-----Line 3-----
        tasks[2].requiredTypes.AddRange(ListConvertStringToTypes(taskInfo.Line3Types));
        tasks[2].requiredNumber.AddRange(taskInfo.Line3Number);
        //-----Line 4-----
        tasks[3].requiredTypes.AddRange(ListConvertStringToTypes(taskInfo.Line4Types));
        tasks[3].requiredNumber.AddRange(taskInfo.Line4Number);
        //-----Line 5-----
        tasks[4].requiredTypes.AddRange(ListConvertStringToTypes(taskInfo.Line5Types));
        tasks[4].requiredNumber.AddRange(taskInfo.Line5Number);

        Debug.Log("Tasks info was successfully loaded");
    }

    public void LoadTaskInfo(int line)
    {
        FullLineTask lineTask = tasks[line - 1];
        switch (line)
        {
            case 1:
                lineTask.requiredTypes.AddRange(ListConvertStringToTypes(taskInfo.Line1Types));
                lineTask.requiredNumber.AddRange(taskInfo.Line1Number);
                break;
            case 2:
                lineTask.requiredTypes.AddRange(ListConvertStringToTypes(taskInfo.Line2Types));
                lineTask.requiredNumber.AddRange(taskInfo.Line2Number);
                break;
            case 3:
                lineTask.requiredTypes.AddRange(ListConvertStringToTypes(taskInfo.Line3Types));
                lineTask.requiredNumber.AddRange(taskInfo.Line3Number);
                break;
            case 4:
                lineTask.requiredTypes.AddRange(ListConvertStringToTypes(taskInfo.Line4Types));
                lineTask.requiredNumber.AddRange(taskInfo.Line4Number);
                break;
            case 5:
                lineTask.requiredTypes.AddRange(ListConvertStringToTypes(taskInfo.Line5Types));
                lineTask.requiredNumber.AddRange(taskInfo.Line5Number);
                break;
        }
        Debug.Log("Task info was successfully loaded");
    } 

    public List<train.Types> ListConvertStringToTypes(List<string> list)
    {
        List<train.Types> newList = new List<train.Types>();
        foreach (var value in list)
            newList.Add(HelpFunctions.StringToType(value));
        return newList;
    }

    public void SaveTaskInfo()
    {
        taskInfo.CLearAll();

        //-----Line 1-----
        if (tasks.Length > 0)
        {
            foreach (var type in tasks[0].requiredTypes)
                taskInfo.Line1Types.Add(type.ToString());
            foreach (var n in tasks[0].requiredNumber)
                taskInfo.Line1Number.Add(n);
        }
        //-----Line 2-----
        if (tasks.Length > 1)
        {
            foreach (var type in tasks[1].requiredTypes)
                taskInfo.Line2Types.Add(type.ToString());
            foreach (var n in tasks[1].requiredNumber)
                taskInfo.Line2Number.Add(n);
        }
        //-----Line 3-----
        if (tasks.Length > 2)
        {
            foreach (var type in tasks[2].requiredTypes)
                taskInfo.Line3Types.Add(type.ToString());
            foreach (var n in tasks[2].requiredNumber)
                taskInfo.Line3Number.Add(n);
        }
        //-----Line 4-----
        if (tasks.Length > 3)
        {
            foreach (var type in tasks[3].requiredTypes)
                taskInfo.Line4Types.Add(type.ToString());
            foreach (var n in tasks[3].requiredNumber)
                taskInfo.Line4Number.Add(n);
        }
        //-----Line 5-----
        if (tasks.Length > 4)
        {
            foreach (var type in tasks[4].requiredTypes)
                taskInfo.Line5Types.Add(type.ToString());
            foreach (var n in tasks[4].requiredNumber)
                taskInfo.Line5Number.Add(n);
        }
        //-------------------------------------------
        

        //---Saving to File---
        File.WriteAllText(path, JsonUtility.ToJson(taskInfo));
        Debug.Log("Task info was saved");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveTaskInfo();
        }
    }
}

[Serializable]
public class TaskInfo
{
    //-----Line 1-----
    public List<string> Line1Types;
    public List<int> Line1Number;
    //-----Line 2-----
    public List<string> Line2Types;
    public List<int> Line2Number;
    //-----Line 3-----
    public List<string> Line3Types;
    public List<int> Line3Number;
    //-----Line 4-----
    public List<string> Line4Types;
    public List<int> Line4Number;
    //-----Line 5-----
    public List<string> Line5Types;
    public List<int> Line5Number;

  
    public void CLearAll()
    {
        //-----Line 1-----
        Line1Types.Clear();
        Line1Number.Clear();
        //-----Line 2-----
        Line2Types.Clear();
        Line2Number.Clear();
        //-----Line 3-----
        Line3Types.Clear();
        Line3Number.Clear();
        //-----Line 4-----
        Line4Types.Clear();
        Line4Number.Clear();
        //-----Line 5-----
        Line5Types.Clear();
        Line5Number.Clear();
    }
}
