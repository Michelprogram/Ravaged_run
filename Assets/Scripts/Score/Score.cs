using System;
using Newtonsoft.Json.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Score
{
    public string name;

    public int point;

    public string difficulty;

    public string time;

    public Score(string name, int point, Shared.Difficulty difficulty, string time)
    {
        this.name = name;
        this.point = point;
        this.time = time;
        this.difficulty = difficulty.ToString();
    }

    public string ToJSON()
    {
        return JsonUtility.ToJson(this);
    }

    static public Score FromJSON(string json)
    {
        return JsonUtility.FromJson<Score>(json);
    }

    public override string ToString()
    {
        return this.name + " : " + this.point + " in " + this.time + " in " + this.difficulty;
    }

    public string GetDifficulty()
    {
        return difficulty;
    }

    public void SetDifficulty(string difficulty)
    {
        this.difficulty = difficulty;
    }

    public string GetTime()
    {
        return time;
    }

    public void SetTime(string time)
    {
        this.time = time;
    }

    public string GetName()
    {
        return name;
    }

    public void SetName(string newName)
    {
        name = newName;
    }

    public void SetPoint(int newPoint)
    {
        point = newPoint;
    }

    public void AddPoint(int point)
    {
        this.point += point;
    }

    public void UpPoint()
    {
        point++;
    }

    public int GetPoint()
    {
        return point;
    }

    public string GetPointStr()
    {
        return point.ToString();
    }
}