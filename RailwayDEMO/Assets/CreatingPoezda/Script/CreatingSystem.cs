using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingSystem : MonoBehaviour {

    public CameraMove cameraMove;
    public int maxSize = 20;
    public GameObject[] places = new GameObject[5];
    public GameObject[] lokomotiwi = new GameObject[5]; // prefabs
    public GameObject[] sostawi = new GameObject[5];    // prefabs
    public GameObject[] choseble = new GameObject[5];   // on scene
    public GameObject createPoint;
    public List<GameObject> Wagoni = new List<GameObject>(); // 0 - lokomotiw , 1.. sostawi
    public bool change; // change lokomotiw and sostaw
    public bool lokomotiwExist = false;
    public float current;
    public GameObject firstSostaw;  // его место

    public bool deleted;
    public int deletedNumber;

    public float range;
    public float width;

    // Use this for initialization
    void Start() {
        cameraMove = FindObjectOfType<CameraMove>();
        firstSostaw = new GameObject();
        firstSostaw.transform.position = new Vector3(createPoint.transform.position.x , createPoint.transform.position.y , createPoint.transform.position.z);
        current = createPoint.transform.position.x;
        Wagoni.Add(null); // for lokomotiw
        for (int i = 0; i < 5; i++) 
        {
            if (lokomotiwi[i] != null) choseble[i] = GameObject.Instantiate(lokomotiwi[i], places[i].transform);
            if (choseble[i] != null)
            {
                choseble[i].GetComponent<ChoseSostaw>().CreatingSystem = this;
                choseble[i].GetComponent<ChoseSostaw>().currentPosition = createPoint;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (cameraMove.createPoezd)
        {
            deleted = false;
            for (int i = 0; i < Wagoni.Count; i++)
            {
                if (Wagoni[i] == null)
                {
                    deleted = true;
                    if (i == 0)
                    {
                        if (lokomotiwExist) change = true;
                    }
                    else
                    {
                        deletedNumber = i;
                    }
                }
            }
            if (deleted == false)
            {
                for (int i = 0; i < Wagoni.Count; i++)
                {

                    Wagoni[i].GetComponent<DeleteWagon>().canDelete = true;
                    Wagoni[i].GetComponent<DeleteWagon>().descriptionText = "DELETE THIS";
                }
            }
            else
            {
                if ((Wagoni.Count == 20) && (choseble[0] == null))
                {
                    if (Wagoni[0] != null) Changing();
                    Changing();
                }
                for (int i = 0; i < Wagoni.Count; i++)
                {
                    if (Wagoni[i] != null)
                    {
                        Wagoni[i].GetComponent<DeleteWagon>().canDelete = false;
                        Wagoni[i].GetComponent<DeleteWagon>().descriptionText = "CHANGE DELETED";
                    }
                }
            }
            if (change)
            {
                Changing();
            }
            if (Wagoni[0] != null)
            {
                Wagoni[0].GetComponent<snake>().Wagoni = Wagoni;
            }
            if ((Wagoni.Count == maxSize) && (!deleted))
            {
                for (int i = 0; i < choseble.Length; i++)
                {
                    GameObject.Destroy(choseble[i]);
                }
            }
        }
    }

    public void Changing()
    {
        for (int i = 0; i < 5; i++)
        {
            
            GameObject.Destroy(choseble[i]);
            if ((lokomotiwExist) && (lokomotiwi[i] != null))
            {
                choseble[i] = GameObject.Instantiate(lokomotiwi[i], places[i].transform);
                choseble[i].GetComponent<ChoseSostaw>().CreatingSystem = this;
                choseble[i].GetComponent<ChoseSostaw>().currentPosition = createPoint;

            }
            if ((sostawi[i] != null) && (!lokomotiwExist)) // on sozdaet na pustom meste bez utochneniya
            {
                
                choseble[i] = GameObject.Instantiate(sostawi[i], places[i].transform);
                choseble[i].GetComponent<ChoseSostaw>().CreatingSystem = this;
                choseble[i].GetComponent<ChoseSostaw>().currentPosition = createPoint;
            }
        }
        if (lokomotiwExist) lokomotiwExist = false;
        else lokomotiwExist = true;
        change = false;
    }

    public void End()
    {
        cameraMove.place = 0;
        cameraMove.createPoezd = false;
        for (int i = 0; i < Wagoni.Count; i++)
        {
            Wagoni[i].GetComponent<DeleteWagon>().canDelete = false;
        }
        for (int i = 0; i < choseble.Length; i++)
        {
            GameObject.Destroy(choseble[i]);
        }
    } 

    public void StartCreating(GameObject startPoint , int createPointNumber) //задать точку начала построения поезда и номер пункта строительства
    {
        for (int i = 0; i < Wagoni.Count; i++)
        {
            Wagoni[i].GetComponent<DeleteWagon>().canDelete = true;
        }
        cameraMove.StartCreating(createPointNumber);
        createPoint = startPoint;
        firstSostaw.transform.position = new Vector3(createPoint.transform.position.x, createPoint.transform.position.y, createPoint.transform.position.z);
        current = createPoint.transform.position.x;
        Wagoni.Add(null); // for lokomotiw
        for (int i = 0; i < 5; i++)
        {
            if (lokomotiwi[i] != null) choseble[i] = GameObject.Instantiate(lokomotiwi[i], places[i].transform);
            if (choseble[i] != null)
            {
                choseble[i].GetComponent<ChoseSostaw>().CreatingSystem = this;
                choseble[i].GetComponent<ChoseSostaw>().currentPosition = createPoint;
            }
        }
    }
}
