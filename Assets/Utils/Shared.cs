using System;
using UnityEngine.Events;

public class Shared
{
    public Shared()
    {
    }

    public static bool keyboard = true, pause = false;

    public static UnityEvent arrival = new UnityEvent();
    public static UnityEvent obstacle = new UnityEvent();

    public static int difficulty = 1;

    public static int life = 2;

    public static void ResetVariable()
    {
        keyboard = true;
        pause = false;
        difficulty = 1;
        life = 2;
    }

    public static void SetDifficulty(int d)
    {
        difficulty = d;
    }

    public static int GetDifficulty()
    {
        return difficulty;
    }

    public static void SetLife(int d)
    {
        life = d;
    }

    public static int GetLife()
    {
        return life;
    }

    public static string GetLifeStr()
    {
        return life+"";
    }

    public static void SetKeyboard(bool flag)
    {
        keyboard = flag;
    }

    public static bool GetKeyboard()
    {
        return keyboard;
    }

    public static void SetPause(bool flag)
    {
        pause = flag;
    }

    public static bool GetPause()
    {
        return pause;
    }

}

