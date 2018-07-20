using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWagon : Interactable
{
    /*
    public bool canDelete;
    public bool isLoko;
    public CreatingSystem creatingSystem;

    private void Start()
    {
        creatingSystem = FindObjectOfType<CreatingSystem>();
        canDelete = true;
    }

    private void OnMouseDown()
    {
        if (canDelete)
        {
            OnMouseExit();
            if (creatingSystem.Wagoni.Count == creatingSystem.maxSize)
            {
                creatingSystem.Changing();
            }
            creatingSystem.Wagoni[0].GetComponent<snake>().Wagoni = creatingSystem.Wagoni;
            if ((creatingSystem.Wagoni.Count == 20) && (creatingSystem.choseble[0] == null))
            {
                if (creatingSystem.Wagoni[0] != null) creatingSystem.Changing();
                creatingSystem.Changing();
            }
            for (int i = 0; i < creatingSystem.Wagoni.Count; i++)
            {
                if (creatingSystem.Wagoni[i] != null)
                {
                    creatingSystem.Wagoni[i].GetComponent<DeleteWagon>().canDelete = false;
                    creatingSystem.Wagoni[i].GetComponent<DeleteWagon>().descriptionText = "CHANGE DELETED";
                }
            }
            if (isLoko)
            {
                creatingSystem.lokomotiwExist = false;
                creatingSystem.Changing();
            }
            creatingSystem.deleted = true;
            Destroy(this.gameObject);
        }
        
    }
    */
}
