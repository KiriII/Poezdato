using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowUI : MonoBehaviour {

	private Animator anim;

	void Start () 
	{
		anim = GetComponent<Animator>();

		EventHandler.OnTimeScaleChanged += CheckTimeScale;
		EventHandler.OnCreating += HideOrShow;
	}

	private void OnDisable() 
	{
		EventHandler.OnTimeScaleChanged -= CheckTimeScale;
		EventHandler.OnCreating -= HideOrShow;
	}
	
	public void CheckTimeScale(bool stop)
    {
		int direction = stop ? -1 : 1;
        anim.SetInteger("direction", direction);
    }

	public void HideOrShow(bool hide)
	{
		int direction = hide ? -1 : 1;
        anim.SetInteger("direction", direction);
	}
}
