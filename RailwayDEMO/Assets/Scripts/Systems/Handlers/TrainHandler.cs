using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainHandler : MonoBehaviour {

	// Destination control
	public delegate void DestinationHandler(GameObject destination);
    public static event DestinationHandler OnDestinationChanged;

	// Movement events
    public delegate void MovementHandler(GameObject self);
    public static event MovementHandler OnDeparture;
    public static event MovementHandler OnArrival;
    public static event MovementHandler OnStop;

	
	public static void DestinationChanged(GameObject destination)
    {
        OnDestinationChanged?.Invoke(destination);
    }

    public static void Departure(GameObject self)
    {
        OnDeparture?.Invoke(self);
    }

    public static void Arrival(GameObject self)
    {
        OnArrival?.Invoke(self);
    }

    public static void Stop(GameObject self)
    {
        OnStop?.Invoke(self);
    }
}
