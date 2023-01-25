using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private TrancheManager trancheManager;

    private int obstacle, levelSize;

    // Use this for initialization
    void Start()
	{
		InitTrancheManager();

        switch (Shared.GetDifficulty())
        {
            case 1:
                obstacle = 2;
                levelSize = 10;
                break;
            case 2:
                obstacle = 5;
                levelSize = 13;
                break;
            case 3:
                obstacle = 13;
                levelSize = 20;
                break;
            case 4:
                obstacle = 15;
                levelSize = 25;
                break;
        }

        trancheManager.CreateLevel(obstacle, levelSize);

	}

    private void InitTrancheManager()
    {

        var start = GameObject.Find("Start");
        var end = GameObject.Find("End");

        var bigObstacleLeft = GameObject.Find("BigObstacleLeft");
        var rightObstacle = GameObject.Find("RightObstacle");

        var botObstacle = GameObject.Find("BotObstacle");
        var topObstacle = GameObject.Find("TopObstacle");

		var middleObstacle = GameObject.Find("MiddleObstacle");

        trancheManager = new TrancheManager(start, end, bigObstacleLeft, rightObstacle, botObstacle, topObstacle, middleObstacle);

    }
}

