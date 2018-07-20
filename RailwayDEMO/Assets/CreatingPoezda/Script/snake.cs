using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using train;

public class snake : MonoBehaviour {

    //[HideInInspector]
    //public int numberInTrain;
    
    //[HideInInspector]
    public List<GameObject> Wagoni = null; // dlya lokomotiva
    public Transform back;

    private Train it;
    private float speed;
    private const float SPEED_K = 0.2f;

    private bool arraysInitiated;
    private List<Train> WagoniTrain;
    private List<snake> WagoniSnake;
    private List<Transform> WagoniTransform;

    private bool creating;

	// Use this for initialization
	void Start () 
    {

        back.transform.position = new Vector3(transform.position.x - transform.localScale.z / 2, transform.position.y , transform.position.z );
        it = GetComponent<Train>();
        speed = it.CurrentSpeed;

        arraysInitiated = false;
        WagoniTrain = new List<Train>();
        WagoniSnake = new List<snake>();
        WagoniTransform = new List<Transform>();

        TrainHandler.OnSpeedChanged += UpdateSpeed;
	}

    private void OnDisable() 
    {
        TrainHandler.OnSpeedChanged -= UpdateSpeed;
    }

    private void Update() 
    {        
        transform.Translate(Vector3.forward * speed * SPEED_K * Time.deltaTime);
    }

    private void UpdateSpeed(GameObject self)
    {
        if (self == this.gameObject)
            speed = self.GetComponent<Train>().CurrentSpeed;

        if (!arraysInitiated)
            InitArrays();
        
        for (int i = 1; i < Wagoni.Count; i++)
        {
            if ((Wagoni[i] != null) && (Wagoni[i - 1] != null))
            {
                WagoniTrain[i].SoftSetSpeed(speed);
                WagoniSnake[i].speed = speed;
                WagoniTransform[i].LookAt(WagoniSnake[i - 1].back);
            }
        }  
    }

    private void InitArrays()
    {
        WagoniTrain.Capacity = Wagoni.Count;
        WagoniSnake.Capacity = Wagoni.Count;
        WagoniTransform.Capacity = Wagoni.Count;
        
        for (int i = 0; i < Wagoni.Count; i++)
        {
            WagoniTrain.Add(Wagoni[i].GetComponent<Train>());
            WagoniSnake.Add(Wagoni[i].GetComponent<snake>());
            WagoniTransform.Add(Wagoni[i].GetComponent<Transform>());
        }
        arraysInitiated = true;
    }
}
