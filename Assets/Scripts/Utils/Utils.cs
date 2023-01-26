using System;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
	public Utils()
	{
	}

	public static void ToggleCanvas(GameObject screen)
	{
        var active = screen.activeInHierarchy;
        screen.SetActive(!active);
    }

    //Shuffle list
    public static void Shuffle<T>(List<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }

    public static float SpeedByDifficulty(float factor)
    {
        switch (Shared.GetDifficulty())
        {
            default:
            case Shared.Difficulty.Easy:
                return factor * 2;
            case Shared.Difficulty.Normal:
                return factor * 2.5f;
            case Shared.Difficulty.Hard:
                return factor * 3;
            case Shared.Difficulty.Xtrem:
                return factor * 3.5f;
        }
    }
}

