using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Player", fileName = "Default")]

public class PlayerData : ScriptableObject
{
    public float FuelLevel;
    public int MaxFuelLevel;
    public int HP;
    public int DamageForce;
    public int DamageTime;

    public int powerTurbo;
    public int powerTurn;

    public void AddFuel_(float how)
    {
        FuelLevel = Mathf.Min(FuelLevel + how, MaxFuelLevel);
    }

    public bool HasFuel_()
    {
        return FuelLevel > 0;
    }
}
