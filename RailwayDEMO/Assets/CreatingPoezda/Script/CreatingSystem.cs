using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using train;

public class CreatingSystem : MonoBehaviour {

    public CameraMove cameraMove;
    public int maxSize = 20;
    //public GameObject[] places = new GameObject[5];
    public GameObject[] lokomotiwi = new GameObject[5]; // prefabs
    public GameObject[] sostawi = new GameObject[5];    // prefabs
    //[HideInInspector]
    public GameObject[] choseble = new GameObject[5];   // on scene
    public GameObject createPoint;
    //[HideInInspector]
    //public List<GameObject> Wagoni = new List<GameObject>(); // 0 - lokomotiw , 1.. sostawi
    //[HideInInspector]
    //public bool lokomotiwExist;
    //[HideInInspector]
    public float current;
    [HideInInspector]
    public GameObject firstSostaw;  // его место
    //[HideInInspector]
    //public bool deleted;
    //[HideInInspector]
    //public int deletedNumber;

    public float range;
    public float width;

    [HideInInspector]
    public bool isCreating;

    [HideInInspector]
    public int sostawCount;
    [HideInInspector]
    private int lokomotCount;
    public Transform[] trainsStarts;
    [HideInInspector]
    float time = 0;

    public GameObject[] NeedPlaces;
    public Text[] NeedTextes;
    public Text line;
    public Text startGoWagon;

    // Use this for initialization
    private void Awake() 
    {
        int i = 0;
        while (sostawi[i] != null)
        {
            i++;
        }
        sostawCount = i;  // считаем сколько есть префабов 
        int j = 0;
        while (lokomotiwi[j] != null)
        {
            j++;
        }
        lokomotCount = j;

        //deleted = false;
        //lokomotiwExist = false;
        isCreating = false;
        cameraMove = FindObjectOfType<CameraMove>();
        firstSostaw = new GameObject();
        firstSostaw.transform.position = new Vector3(createPoint.transform.position.x , createPoint.transform.position.y , createPoint.transform.position.z);
        current = createPoint.transform.position.x;

        //EventHandler.CreatingChanged(false);     // no creation 
    }

    /*
    public void Changing()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject.Destroy(choseble[i]);
            if ((!lokomotiwExist) && (lokomotiwi[i] != null))
            {
                choseble[i] = GameObject.Instantiate(lokomotiwi[i], places[i].transform);
                choseble[i].GetComponent<ChoseSostaw>().CreatingSystem = this;
                choseble[i].GetComponent<ChoseSostaw>().currentPosition = createPoint;

            }
            if ((sostawi[i] != null) && (lokomotiwExist)) // on sozdaet na pustom meste bez utochneniya
            {
                
                choseble[i] = GameObject.Instantiate(sostawi[i], places[i].transform);
                choseble[i].GetComponent<ChoseSostaw>().CreatingSystem = this;
                choseble[i].GetComponent<ChoseSostaw>().currentPosition = createPoint;
            }
        }
    }
    */

    public void End(snake lokomotiw)
    {
        trainsStarts[lokomotiw.GetComponent<snake>().lokoPoint].GetComponent<lokoPoint>().current.transform.position
            = new Vector3(trainsStarts[lokomotiw.GetComponent<snake>().lokoPoint].GetComponent<lokoPoint>().transform.position.x - range / 1.5f - width / 2, 
            trainsStarts[lokomotiw.GetComponent<snake>().lokoPoint].transform.position.y, trainsStarts[lokomotiw.GetComponent<snake>().lokoPoint].transform.position.z);           
        createLoko(lokomotiw.GetComponent<snake>().lokoPoint);
        //isCreating = false;
        //cameraMove.place = 0;
        //cameraMove.createPoezd = false;
        //for (int i = 0; i < Wagoni.Count; i++)
        //{
        //    Wagoni[i].GetComponent<DeleteWagon>().canDelete = false;
        //}
        //for (int i = 0; i < choseble.Length; i++)
        //{
        //    GameObject.Destroy(choseble[i]);
        //}

        //TrainHandler.Departure(Wagoni[0]);       // departure event
        //EventHandler.CreatingChanged(false);     // creation end
    } 

    public void StartCreating(GameObject startPoint , int createPointNumber) //задать точку начала построения поезда и номер пункта строительства
    {
        isCreating = true;
        //for (int i = 0; i < Wagoni.Count; i++)
        //{
        //    if (Wagoni[i] != null) {
        //        Wagoni[i].GetComponent<DeleteWagon>().canDelete = true;
        //    }
        //}
        cameraMove.StartCreating(createPointNumber);
        //createPoint = startPoint;
        //firstSostaw = new GameObject();
        //firstSostaw.transform.position = new Vector3(createPoint.transform.position.x, createPoint.transform.position.y, createPoint.transform.position.z);
        //current = createPoint.transform.position.x;
        //Wagoni.Add(null); // for lokomotiw
        //for (int i = 0; i < 5; i++)
        //{
        //    if (lokomotiwi[i] != null) choseble[i] = GameObject.Instantiate(lokomotiwi[i], places[i].transform);
        //    if (choseble[i] != null)
        //    {
        //        choseble[i].GetComponent<ChoseSostaw>().CreatingSystem = this;
        //        choseble[i].GetComponent<ChoseSostaw>().currentPosition = createPoint;
        //    }
        //}
        for (int i = 0; i < trainsStarts.Length; i++)
        {
            createLoko(i);
        }


        EventHandler.CreatingChanged(true);     // creation start
    }

    private void Update()
    {

        time += Time.deltaTime;
        if (time >= 3.0f)
        {
            goWagon();
            time = 0;
        }

    }

    public void goWagon()
    {
        System.Random rnd = new System.Random();
        int current = rnd.Next(0, sostawCount);
        GameObject currentWagon = Instantiate(sostawi[current]);
        startGoWagon.text = currentWagon.GetComponent<Train>().Name;
        currentWagon.transform.position = createPoint.transform.position;
    }

    public void createLoko(int lokoPos)
    {
        System.Random rnd = new System.Random();
        int current = rnd.Next(0, lokomotCount);
        GameObject currentWagon = Instantiate(lokomotiwi[current]);
        int wagoniNeedCount = rnd.Next(0, sostawCount);
        for (int i = 0; i < sostawCount; i++)
        {
            current = rnd.Next(0, maxSize / sostawCount);
            currentWagon.GetComponent<snake>().WagoniNeeded.Add(current);
        }
        currentWagon.GetComponent<snake>().Wagoni.Add(currentWagon);
        trainsStarts[lokoPos].GetComponent<lokoPoint>().current.lokomotiw = currentWagon.GetComponent<snake>();
        trainsStarts[lokoPos].GetComponent<lokoPoint>().ForUI = currentWagon.GetComponent<snake>().WagoniNeeded;
        currentWagon.transform.position = new Vector3(trainsStarts[lokoPos].position.x , trainsStarts[lokoPos].position.y , trainsStarts[lokoPos].position.z);
        currentWagon.GetComponent<snake>().lokoPoint = lokoPos;
    }


}
