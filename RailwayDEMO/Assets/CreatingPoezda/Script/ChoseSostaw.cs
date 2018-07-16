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

    private void OnMouseDown()
    {
        current = CreatingSystem.current;
        GameObject currentWagon = Instantiate(onRoad);
        if (isLoko)
        {
            CreatingSystem.change = true;
            CreatingSystem.Wagoni[0] = currentWagon;
            if (CreatingSystem.deleted)
            {
                if (CreatingSystem.Wagoni.Count == 1)
                {
                    CreatingSystem.current = CreatingSystem.firstSostaw.transform.position.x - onRoad.transform.localScale.z - 1;
                    CreatingSystem.createPoint.transform.position = new Vector3(CreatingSystem.firstSostaw.transform.position.x - onRoad.transform.localScale.z,
                        CreatingSystem.firstSostaw.transform.position.y , CreatingSystem.firstSostaw.transform.position.z);
                    
                }
                currentWagon.transform.position = CreatingSystem.firstSostaw.transform.position;
            }
        }
        else
        {
            if (CreatingSystem.deleted) 
            {
                current = CreatingSystem.firstSostaw.transform.position.x - onRoad.transform.localScale.z - // локоматив
                     (CreatingSystem.deletedNumber - 1 ) * (onRoad.transform.localScale.z + 1 );
                currentWagon.transform.position = new Vector3(current , CreatingSystem.firstSostaw.transform.position.y , CreatingSystem.firstSostaw.transform.position.z);
                CreatingSystem.Wagoni[CreatingSystem.deletedNumber] = currentWagon;
            }
            else CreatingSystem.Wagoni.Add(currentWagon);
        }
        if (!CreatingSystem.deleted)
        {
            CreatingSystem.createPoint.transform.position = new Vector3(current, CreatingSystem.createPoint.transform.position.y,
                CreatingSystem.createPoint.transform.position.z);
            CreatingSystem.current -= onRoad.transform.localScale.z + 1f;
            currentWagon.transform.position = CreatingSystem.createPoint.transform.position;
        }
    }
}
