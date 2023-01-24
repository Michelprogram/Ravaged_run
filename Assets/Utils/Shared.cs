using System;
using UnityEngine.Events;

public class Shared
{
    public Shared()
    {
    }

    public static bool keyboard = true;

    public static UnityEvent arrival = new UnityEvent();
    public static UnityEvent obstacle = new UnityEvent();

    public static int difficulty = 1;

    public static void SetDifficulty(int d)
    {
        difficulty = d;
    }

    public static int GetDifficulty()
    {
        return difficulty;
    }

    public static void SetKeyboard(bool flag)
    {
        keyboard = flag;
    }

    public static bool GetKeyboard()
    {
        return keyboard;
    }

}

