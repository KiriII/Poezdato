using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseSostaw : Interactable
{

    public GameObject onRoad;
    public CreatingSystem CreatingSystem;
    public bool isLoko;
    private float current;
    public GameObject currentPosition;
    public float range;
    public float width;
    //private int deletedNumber;

    public void Start()
    {
        
        width = CreatingSystem.width;
        range = CreatingSystem.range;    
    }

    /*
    private void OnMouseDown()
    {
        for (int i = 0; i < CreatingSystem.Wagoni.Count; i++)
        {
            if (CreatingSystem.Wagoni[i] != null)
            {
                CreatingSystem.Wagoni[i].GetComponent<DeleteWagon>().canDelete = true;
                CreatingSystem.Wagoni[i].GetComponent<DeleteWagon>().descriptionText = "DELETE THIS";
            }
        }
        current = CreatingSystem.current;
        if ((CreatingSystem.Wagoni.Count != CreatingSystem.maxSize) || (CreatingSystem.deleted))
        {
            GameObject currentWagon = Instantiate(onRoad);
            if (isLoko)
            {
                CreatingSystem.lokomotiwExist = true;
                CreatingSystem.Changing();
                CreatingSystem.Wagoni[0] = currentWagon;
                CreatingSystem.Wagoni[0].GetComponent<snake>().Wagoni = CreatingSystem.Wagoni;
                currentWagon.transform.position = CreatingSystem.firstSostaw.transform.position;
                if (CreatingSystem.Wagoni.Count == 1)
                {
                    Debug.Log("smth");
                    CreatingSystem.current = CreatingSystem.firstSostaw.transform.position.x - width - range;
                    CreatingSystem.createPoint.transform.position = new Vector3(CreatingSystem.firstSostaw.transform.position.x - width - range,
                        CreatingSystem.firstSostaw.transform.position.y, CreatingSystem.firstSostaw.transform.position.z);
                }
                if (CreatingSystem.deleted)
                {
                    CreatingSystem.deleted = false;
                }
            }
            else
            {
                CreatingSystem.Wagoni[0].GetComponent<snake>().Wagoni = CreatingSystem.Wagoni;
                if (CreatingSystem.deleted)
                {
                    for (int i = 0; i < CreatingSystem.Wagoni.Count; i++)
                    {
                        if (CreatingSystem.Wagoni[i] == null) deletedNumber = i;      // on tolko 1
                    }
                    current = CreatingSystem.firstSostaw.transform.position.x - width - range - // локоматив
                         (deletedNumber - 1) * (width + range);
                    currentWagon.transform.position = new Vector3(current, CreatingSystem.firstSostaw.transform.position.y, CreatingSystem.firstSostaw.transform.position.z);
                    CreatingSystem.Wagoni[deletedNumber] = currentWagon;
                    CreatingSystem.deleted = false;
                }
                else
                {
                    CreatingSystem.current -= width + range;
                    CreatingSystem.createPoint.transform.position = new Vector3(current, CreatingSystem.createPoint.transform.position.y,
                                                                CreatingSystem.createPoint.transform.position.z);
                    currentWagon.transform.position = CreatingSystem.createPoint.transform.position;
                    CreatingSystem.Wagoni.Add(currentWagon);
                }
            }
        }
        if (CreatingSystem.Wagoni.Count == CreatingSystem.maxSize)
        {
            for (int i = 0; i < CreatingSystem.choseble.Length; i++)
            {
                GameObject.Destroy(CreatingSystem.choseble[i]);
            }
        }
    }
    */
}
