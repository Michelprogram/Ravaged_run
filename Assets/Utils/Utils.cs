using System;
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
}

