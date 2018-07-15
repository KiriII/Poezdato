﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace train
{
    // Base train class to control characteristics and states 
    public class Train : MonoBehaviour {

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


        private void Start()
        {
            state = new State(false, true, false); // train state init
            
            // method subscription to time management 
            EventHandler.OnTimeScaleChanged += CheckTimeScale;
        }

        void OnDisable()
        {
            // methods deletion from events
            EventHandler.OnTimeScaleChanged -= CheckTimeScale;
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
            if (state.isReady)
            {
                state.isStopped = false;
                TrainHandler.Departure(gameObject);     // departure event
            }       
        }

        public void Arrival()
        {
            state.isStopped = true;
            state.isArrived = true;
            TrainHandler.Arrival(gameObject);           // arrival event
        }

        public void Stop(){
            state.isStopped = true;
            TrainHandler.Stop(gameObject);              // stop event
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