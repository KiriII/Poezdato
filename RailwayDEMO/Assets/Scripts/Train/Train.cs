using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace train
{
    // Base train class to control characteristics and states 
    public class Train : Interactable {

        [Tooltip("Train name")]
        public string Name = "Basic train";

        [Tooltip("Train special identificator")]
        public int ID = 0;

        [Tooltip("Train carriage type")]
        public Types type;

        [Tooltip("Max possible train speed")]
        [Range(1, 300)]        
        public float MaxSpeed = 120;

        [Tooltip("Last destination")]
        public GameObject destination;

        [Tooltip("Description of the train")]
        public string Info = "Some super interesting information";

        private float CurrentSpeed;

        private struct State 
        {
            public bool isReady;
            public bool isStopped;
            public bool isArrived;

            public State(bool _isReady, bool _isStopped, bool _isArrived)
            {
                isReady = _isReady;
                isStopped = _isStopped;
                isArrived = _isArrived;
            }
        }
        private State state;  // struct with train current state  
        private Interactable interComponent;
        private CreatingSystem cS;

        private void Start()
        {
            state = new State(false, true, false); // train state init
            interComponent = GetComponent<DeleteWagon>();
            cS = FindObjectOfType<CreatingSystem>();
            
            // method subscription to time management 
            EventHandler.OnTimeScaleChanged += CheckTimeScale;
            EventHandler.OnTriggerEnter +=Stop;
            TrainHandler.OnDeparture += Departure;
        }

        void OnDisable()
        {
            // methods deletion from events
            EventHandler.OnTimeScaleChanged -= CheckTimeScale;
            EventHandler.OnTriggerEnter -=Stop;
            TrainHandler.OnDeparture -= Departure;
            // eventHandler
        }

        public void CheckTimeScale(bool stop)
        {
            state.isStopped = stop;
        }

        public void SetNewDestination(GameObject newDest)
        {
            destination = newDest;                      // new destination setup
            TrainHandler.DestinationChanged(newDest);   // new destination event
        }

        public void Departure()
        {
            state.isStopped = false;
            Info = type.ToString();              
            descriptionText = Info;
            interComponent.descriptionText = Info;
            cS.Wagoni[0].GetComponent<snake>().speed = MaxSpeed / 10;
            Debug.Log("Go");
        }

        public void Arrival()
        {
            state.isStopped = true;
            state.isArrived = true;
            TrainHandler.Arrival(gameObject);           // arrival event
        }

        public void Stop(){
            if (isStopped) return;
            state.isStopped = true;
            TrainHandler.Stop(gameObject);              // stop event
            cS.Wagoni[0].GetComponent<snake>().speed = 0;
        }


        //---Getters and setters--- 
        public bool IsReady(){
            return state.isReady;
        }

        public void SetReady(bool _isReady){
            state.isReady = _isReady;
        }

        public bool IsStopped(){
            return state.isStopped;
        }

        public bool IsArrived(){
            return state.isArrived;
        }
    }
}