using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class UIEvents : MonoBehaviour
{
    public static UIEvents Instance;

    public event Action StartAcelerationEvent = delegate { };
    public event Action StopAcelerationEvent = delegate { };
    public delegate void TurnDelegate(int direction);
    public event TurnDelegate TurnEvent = delegate { };

    private void Awake()
    {
        Instance = this;
    }

    public void StartAceleration()
    {
        StartAcelerationEvent();
    }

    public void FinishedAceleration()
    {
        StopAcelerationEvent();
    }

    public void Turn(int direction)
    {
        TurnEvent(direction);
    }

}
