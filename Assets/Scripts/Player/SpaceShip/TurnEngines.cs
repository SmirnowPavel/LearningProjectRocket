using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEngines : BaseEngine
{
    public PlayerData rocket;

    void Start()
    {
        base.a_power = rocket.powerTurn;  
    }

}
