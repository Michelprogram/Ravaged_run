﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private Map mapManager;
    private ScoreManager scoreManager;

    public GameObject map;

    private int obstacle, levelSize;
    private float scoreFactor;

    // Use this for initialization
    void Start()
	{
        InitTrancheManager();

        scoreManager = new ScoreManager();

        var sc = new Score("Dorian", 300, Shared.Difficulty.Easy, "0");

        scoreManager.SaveScore(sc);

        switch (Shared.GetDifficulty())
        {
            default:
            case Shared.Difficulty.Easy:
                obstacle = 2;
                levelSize = 10;
                break;
            case Shared.Difficulty.Normal:
                obstacle = 5;
                levelSize = 13;
                break;
            case Shared.Difficulty.Hard:
                obstacle = 13;
                levelSize = 20;
                break;
            case Shared.Difficulty.Xtrem:
                obstacle = 15;
                levelSize = 25;
                break;

        }

        mapManager.CreateLevel(obstacle, levelSize);

	}

    private void Update()
    {
        if (Shared.GetPause()) return;
        mapManager.MooveMap();
    }

    private void InitTrancheManager()
    {

        var start = GameObject.Find("Start");
        var end = GameObject.Find("End");
        var clean = GameObject.Find("Clean");

        var bigObstacleLeft = GameObject.Find("BigObstacleLeft");
        var rightObstacle = GameObject.Find("RightObstacle");

        var botObstacle = GameObject.Find("BotObstacle");
        var topObstacle = GameObject.Find("TopObstacle");

		var middleObstacle = GameObject.Find("MiddleObstacle");

        mapManager = new Map(start, end, clean,bigObstacleLeft, rightObstacle, botObstacle, topObstacle, middleObstacle,map);

    }

}

