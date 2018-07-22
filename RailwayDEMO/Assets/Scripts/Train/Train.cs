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
        [HideInInspector]
        public float CurrentSpeed;
        //[HideInInspector]
        public int CurrentLine;

        private float lastSpeed;

        private struct State 
        {
            public bool isReady;
            public bool isStopped;
            public bool isArrived;
            public bool isTracked;

            public State(bool _isReady, bool _isStopped, bool _isArrived, bool _isTracked)
            {
                isReady = _isReady;
                isStopped = _isStopped;
                isArrived = _isArrived;
                isTracked = _isTracked;
            }
        }
        private State state;  // struct with train current state  
        private Interactable interComponent;
        private CreatingSystem cS;

        private void Start()
        {
            
            lastSpeed = MaxSpeed * 2;
            state = new State(false, true, false, false); // train state init
            interComponent = GetComponent<DeleteWagon>();
            cS = FindObjectOfType<CreatingSystem>();
            
            // method subscription to time management 
            EventHandler.OnTimeScaleChanged += CheckTimeScale;
            EventHandler.OnCreating +=ChangeDescription;
            TrainHandler.OnDeparture += Departure;
            if (ID != 0) CurrentSpeed = 20f;
        }

        void OnDisable()
        {
            // methods deletion from events
            EventHandler.OnTimeScaleChanged -= CheckTimeScale;
            EventHandler.OnCreating +=ChangeDescription;
            TrainHandler.OnDeparture -= Departure;            
        }

        public override void CheckTimeScale(bool stop)
        {
            base.CheckTimeScale(stop);
            state.isStopped = stop;
        }

        public override void Interact()
        {
            base.Interact();
            TrainHandler.InfoUpdate(gameObject);
        }

        public void SetNewDestination(GameObject newDest)
        {
            destination = newDest;                      // new destination setup
            TrainHandler.DestinationChanged(newDest);   // new destination event
        }

        public void ChangeDescription(bool change)
        {
            Info = type.ToString();              
            descriptionText = Info;
            interComponent.descriptionText = Info;
        }

        public void Departure(GameObject departedTrain)
        {
            if (departedTrain != gameObject) return;
            state.isStopped = false;            
            SetSpeed(lastSpeed);
        }

        public void Departure()
        {           
            state.isStopped = false;
            Info = type.ToString();              
            descriptionText = Info;
            interComponent.descriptionText = Info;
            SetSpeed(lastSpeed);
        }

        public void Arrival()
        {            
            state.isArrived = true;
            Stop();
            TrainHandler.Arrival(gameObject);                       // arrival event
        }

        public void Stop(){
            if (isStopped) return;
            state.isStopped = true;
            lastSpeed = CurrentSpeed;           
            SetSpeed(0);
            if (!state.isArrived) TrainHandler.Stop(gameObject);    // stop event
        }

        public void SetSpeed(float newSpeed)
        {
            CurrentSpeed = newSpeed;
            TrainHandler.SpeedChange(gameObject);
        }

        public void SoftSetSpeed(float newSpeed)
        {
            CurrentSpeed = newSpeed;
            if (state.isTracked)
                TrainHandler.StateChange(gameObject);
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

        public bool IsTracked(){
            return state.isTracked;
        }

        public void SetTracked(bool _isTracked){
            state.isTracked = _isTracked;
        }
    }
}