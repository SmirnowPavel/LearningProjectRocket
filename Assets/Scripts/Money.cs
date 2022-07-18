using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Money 
{
    static string MONEY = "adad";
    static string CRISTALS = "awexc";

    public static event Action onMoneyChanged = delegate { };
    public static bool CanBuy(int count)
    {
        return MoneyLeft() >= count;
    }

    public static int MoneyLeft()
    {
        return PlayerPrefs.GetInt(MONEY);
    }

    public static void AddMoney(int count)
    {
        WasteMoney(-count);
    }

    public static void WasteMoney(int count)
    {
        PlayerPrefs.SetInt(MONEY, MoneyLeft() - count);
        onMoneyChanged();
    }

    public static int CristalsLeft()
    {
        return PlayerPrefs.GetInt(CRISTALS);
    }

}
