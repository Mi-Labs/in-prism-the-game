using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    // Saves every event in a dictonary with string as key and UnityEvent as value
    private Dictionary<string, UnityEvent> eventDictionary;

    private static EventManager eventManager = null;

    private void Awake()
    {
          DontDestroyOnLoad(this);

        /* Singleton Pattern */

        // If no other instance is there -> save this instance
        if (eventManager == null)
        {
            eventManager = this;
        }

        // if another instance is already there -> destroy this
        else if (eventManager != this)
        {
            Destroy(gameObject);
        }
    }


    public static EventManager Instance
    {
        get
        {
            if(!eventManager)
            {
                eventManager = FindObjectOfType (typeof (EventManager)) as EventManager;

                if(!eventManager)
                {
                    Debug.LogError("One Eventmanager must be active every scene!");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if(eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }


    /// <summary>
    ///  This method adds a listener for a registered event or register a new Event and add a listener
    /// </summary>
    /// <param name="eventName">The name of the event (String)</param>
    /// <param name="listener">The action, that should be listened to</param>
    public static void StartListening (string eventName, UnityAction listener)
    {
        //Create an empty UnityEvent
        UnityEvent thisEvent = null;

        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }


    /// <summary>
    ///  This method stops the listing for that event
    /// </summary>
    /// <param name="eventName">The name of the event (String)</param>
    /// <param name="listener">The Action, that should be listened to</param>
    public static void StopListening(string eventName, UnityAction listener)
    {
        // When there is no eventManager, close this method
        if (eventManager == null) return;

        //Create an empty UnityEvent
        UnityEvent thisEvent = null;

        // Search the dictionary with the eventName as key and give the value-event back
        if (Instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            // Remove the listener from this event
            thisEvent.RemoveListener(listener);
        }
    }


    /// <summary>
    /// This method triggers the event that ist given by the parameter
    /// </summary>
    /// <param name="eventName">The name of the event, that should be triggered</param>
    public static void TriggerEvent (string eventName)
    {
        //Create an empty UnityEvent
        UnityEvent thisEvent = null;

        // Search the dictionary with the eventName as key and give the value-event back
        if(Instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            //
            thisEvent.Invoke();
        }
    }

}
