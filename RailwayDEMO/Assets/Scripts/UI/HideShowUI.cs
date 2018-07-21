using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideShowUI : MonoBehaviour {

	private Animator anim;

	void Start () 
	{
		anim = GetComponent<Animator>();		

		EventHandler.OnTimeScaleChanged += CheckTimeScale;
		EventHandler.OnCreating += HideOrShow;

		Setup();
	}

	public virtual void Setup() 
	{	
		//if (!FindObjectOfType<CreatingSystem>().isCreating)	
			//HideOrShow(true);			
	}

	private void OnDisable() 
	{
		EventHandler.OnTimeScaleChanged -= CheckTimeScale;
		EventHandler.OnCreating -= HideOrShow;
	}
	
	public virtual void CheckTimeScale(bool stop)
    {
		int direction = stop ? -1 : 1;
        anim.SetInteger("direction", direction);
    }

	public virtual void HideOrShow(bool hide)
	{
		int direction = hide ? -1 : 1;
        anim.SetInteger("direction", direction);
	}
}
