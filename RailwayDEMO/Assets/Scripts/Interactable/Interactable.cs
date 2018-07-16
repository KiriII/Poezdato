using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    public bool withOutline = true;    
    public Image description;
    public Text text;
    public string descriptionText = "Do not forget to add description";

    private bool isFocused;
    private GameObject defaultDescription;
    
    private Outline outline;
    private float outlineBoost;
    private Color outlineDefaultColor;
    private Color outlineInteractColor;


    private void Awake()
    {
        if (description == null || text == null)
        {
            defaultDescription = GameObject.FindGameObjectWithTag("Description");
            if (description == null)
                description = defaultDescription.GetComponent<Image>();

            if (text == null)
                text = defaultDescription.transform.GetChild(0).GetComponent<Text>();
        }
        if (withOutline)
        {
            outline = GetComponent<Outline>();
            if (outline == null)
                SetOutline();

            outline.enabled = false;
            outlineBoost = 1.2f;
            outlineDefaultColor = outline.OutlineColor;
            outlineInteractColor = Color.magenta;
        }        
		isFocused = false;
    }

    private void SetOutline()
    {
        gameObject.AddComponent<Outline>();
        outline = GetComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.cyan;
        outline.OutlineWidth = 5f;
    }

    public virtual void Interact()
    {
		Debug.Log("Interacting");
    }

    public virtual void AfterInteract()
    {
    }

    private void OnMouseDown() 
    {
        if (withOutline)
        {
            outline.OutlineColor = outlineInteractColor;
            outline.OutlineWidth *= outlineBoost;
        }
    }

    private void OnMouseUp() 
	{
        if (withOutline)
        {
            outline.OutlineColor = outlineDefaultColor;
            outline.OutlineWidth /= outlineBoost;
        }
		if (isFocused)
		{
			Interact();
		}        		
	}
    
    void OnMouseEnter()
    {        
        if (withOutline)
            outline.enabled = true;
        description.enabled = true;
        SetText();        
		isFocused = true;
    }

    private void OnMouseExit()
    {      
        if (withOutline)
            outline.enabled = false;  
        description.enabled = false;
        RemoveText();        
		isFocused = false;
    }

    public virtual void SetText()
    {
        text.text = descriptionText;
        text.enabled = true;
    }

    public void RemoveText()
    {
        text.text = null;
        text.enabled = false;
    }
}
