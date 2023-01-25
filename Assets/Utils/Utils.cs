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
}

