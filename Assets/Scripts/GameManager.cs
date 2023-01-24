using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private TrancheManager trancheManager;

    // Use this for initialization
    void Start()
	{
		InitTrancheManager();

		var i = 0;
        Vector3 coordinate;


        for (i = 1; i < 3; i++)
		{

            coordinate = new Vector3(0, 0, Constantes.SizeTranche * i);
			trancheManager.GenerateClean(coordinate);
		}

        coordinate = new Vector3(0, 0, Constantes.SizeTranche * i);

        trancheManager.GenerateBigObstacleLeft(coordinate);
	}

	// Update is called once per frame
	void Update()
	{

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

