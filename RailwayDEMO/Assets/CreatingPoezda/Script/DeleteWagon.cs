using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWagon : Interactable
{
    public bool canDelete;
    public bool isLoko;
    public CreatingSystem CreatingSystem;

    private void Start()
    {
        CreatingSystem = FindObjectOfType<CreatingSystem>();
        canDelete = false;
    }

    private void OnMouseDown()
    {
        if (canDelete)
        {
            Destroy(this.gameObject);
        }
        
    }
}
