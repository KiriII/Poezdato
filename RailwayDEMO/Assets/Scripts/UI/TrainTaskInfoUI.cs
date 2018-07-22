using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTaskInfoUI : MonoBehaviour {

	#region Singleton

    public static TrainTaskInfoUI Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("TrainTaskInfoUI error");
            return;
        }
        Instance = this;
		targetLine = 1;
    }

    #endregion 

	public int targetLine = 1;

	private CreatingSystem Cs;

	public FullLineTask[] tasks;

	public List<int> ForUI;

	// Use this for initialization
	void Start () 
	{
		Cs = FindObjectOfType<CreatingSystem>();
		tasks = GetComponents<FullLineTask>();
		targetLine = 1;
	}

	public void UpdateUI()
	{
		ForUI = tasks[targetLine - 1].requiredNumber;
		Debug.Log("Cs.sostawCount" + Cs.sostawCount + "ForUI" + ForUI.Count);
		for (int i = 0; i < Cs.sostawCount; i++)
        {
            if (ForUI[i] >= 0) Cs.NeedTextes[i].text = "X" + ForUI[i];
            else Cs.NeedTextes[i].text = "X" + 0;
        }
	}

	public void SetTarget(int newTargetLine)
	{
		targetLine = newTargetLine;
		UpdateUI();
	}
}
