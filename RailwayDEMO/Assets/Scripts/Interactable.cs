using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    public GameObject detect;    
    public Image description;
    public Text text;
    public string descriptionText = "Do not forget to add description";

    private bool isFocused;
    private GameObject defaultDescription;

	//TODO outline

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

		isFocused = false;
    }

    public virtual void Interact()
    {
		Debug.Log("Interacting");
    }

    public virtual void AfterInteract()
    {
    }

    private void OnMouseUp() 
	{
		if (isFocused)
		{
			Interact();
		}		
	}
    
    void OnMouseEnter()
    {
        if (detect != null)
        {
            try
            {				
                detect.GetComponent<MeshRenderer>().enabled = true;
            }catch(MissingComponentException e)
            {
                Debug.Log("No MeshRenderer");
            }
            description.enabled = true;
            SetText();
        }
		isFocused = true;
    }

    private void OnMouseExit()
    {
        if (detect != null)
        {
            try
            {
                detect.GetComponent<MeshRenderer>().enabled = false;
            }
            catch (MissingComponentException e)
            {
                Debug.Log("No MeshRenderer");
            }
            description.enabled = false;
            RemoveText();
        }
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
