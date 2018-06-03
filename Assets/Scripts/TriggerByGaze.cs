using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerByGaze : MonoBehaviour {
    private DateTime gazeEnteredAt;
    private TimeSpan gazeLengthForTrigger = TimeSpan.FromSeconds(1);
    private bool isGazeEnteredInitialized;

    void Start()
    {
        gazeEnteredAt = DateTime.MinValue;
        isGazeEnteredInitialized = false;
    }

    void GazeEnterFocus()
    {
        gazeEnteredAt = DateTime.Now;
        Debug.Log("Entered focus on game object: " + gameObject.transform.parent.name);
    }

    void GazeLeaveFocus()
    {
        gazeEnteredAt = DateTime.MinValue;
        Debug.Log("Left focus from game object: " + gameObject.transform.parent.name);
    }

    void Update()
    {
        isGazeEnteredInitialized |= (gazeEnteredAt != DateTime.MinValue);
        var isGazeHeld = DateTime.Now - gazeEnteredAt > gazeLengthForTrigger;

        if (isGazeEnteredInitialized && isGazeHeld)
        {
            gazeEnteredAt = DateTime.MinValue;
            isGazeEnteredInitialized = false;
            gameObject.SendMessage("OnTriggerByGaze");
        }
    }

    //void OnTriggerByGaze()
    //{
    //    gazeEnteredAt = DateTime.MinValue;
    //    isGazeEnteredInitialized = false;
    //    Debug.Log("TRIGGERED BY GAZE");
    //}
}
