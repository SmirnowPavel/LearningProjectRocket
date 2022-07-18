using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InformationAboutLevels
{
    public static bool CheckIsOpened(int index)
    {
        if (index == 0)
            return true;
        return GetStarsCount(index - 1) > 0;
    }

    public static int GetStarsCount(int index)
    {
        return Mathf.Min(PlayerPrefs.GetInt("level" + index), 3);
    }

    public static void SetStarsCount(int index, int count)
    {
        PlayerPrefs.SetInt("level" + index, Mathf.Min(GetStarsCount(index), count));
    }

}
