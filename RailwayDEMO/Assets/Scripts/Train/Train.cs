using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace train
{
    public class Train : MonoBehaviour {

        public string Name = "Basic train";
        public int ID = 0;   
        public Types type; 
        [Range(1, 300)]
        public float MaxSpeed = 120;
        public GameObject destination;
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
        private State state;        


        private void Start()
        {
            state = new State(false, true, false);
            type = Types.Default;
            
            EventHandler.OnTimeScaleChanged += CheckTimeScale;
        }

        void OnDisable()
        {
            EventHandler.OnTimeScaleChanged -= CheckTimeScale;
            // eventHandler
        }

        public void CheckTimeScale(bool stop)
        {
            state.isStopped = stop;
        }

        public void SetNewDestination(GameObject newDest)
        {
            destination = newDest;
            EventHandler.DestinationChanged(newDest);
        }

        public void Departure()
        {
            if (state.isReady)
            {
                state.isStopped = false;
                EventHandler.Departure(gameObject);
            }       
        }

        public void Arrival()
        {
            state.isStopped = true;
            state.isArrived = true;
            EventHandler.Arrival(gameObject);
        }

        public void Stop(){
            state.isStopped = true;
            EventHandler.Stop(gameObject);
        }

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