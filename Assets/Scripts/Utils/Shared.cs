using System;
using UnityEngine.Events;

public class Shared
{
    public enum Difficulty
    {
        Easy, Normal, Hard, Xtrem
    }

    public Shared()
    {
    }

    public static bool keyboard = true, pause = false;

    public static UnityEvent arrival = new UnityEvent();
    public static UnityEvent obstacle = new UnityEvent();
    public static UnityEvent start = new UnityEvent();
    public static UnityEvent score = new UnityEvent();

    public static Difficulty difficulty = Difficulty.Easy;

    public static int life = 2;

    public static void ResetVariable()
    {
        keyboard = true;
        pause = false;
        difficulty = Difficulty.Easy;
        life = 2;
    }

    public static void SetDifficulty(Difficulty d)
    {
        difficulty = d;
    }

    public static Difficulty GetDifficulty()
    {
        return difficulty;
    }

    public static string GetDifficultyStr()
    {

        string originalString = difficulty.ToString().ToUpper();
        string spacedString = "";

        for (int i = 0; i < originalString.Length; i++)
        {
            spacedString += originalString[i] + " ";
        }
        return spacedString;
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
        return life.ToString();
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

