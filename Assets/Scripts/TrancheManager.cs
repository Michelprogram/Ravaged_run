using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

public class TrancheManager
{
    private GameObject start, bigObstacleLeft, rightObstacle,botObstacle, topObstacle,end, middleObstacle;

    private List<GameObject> obstacles;

    private int size;

    public TrancheManager(GameObject start, GameObject end, GameObject bigObstacleLeft, GameObject rightObstacle,GameObject botObstacle, GameObject topObstacle, GameObject middleObstacle) {
        this.start = start;
        this.end = end;
        this.bigObstacleLeft = bigObstacleLeft;
        this.rightObstacle = rightObstacle;
        this.botObstacle = botObstacle;
        this.topObstacle = topObstacle;
        this.middleObstacle = middleObstacle;

        obstacles = new List<GameObject> { bigObstacleLeft, rightObstacle, botObstacle, topObstacle, middleObstacle };
    }

    public void CreateLevel(int obstacles, int levelSize)
    {

        var cleansTranches = levelSize - obstacles;

        //Generate one obstacle with clean tranches
        var obstaclesObject = PickObstacles(obstacles);
        var cleansTranchesObject = CleanTranches(cleansTranches);
        var rnd = Random.Range(0,10);

        var line = new List<GameObject>();

        var i = 0;
        Vector3 coordinate = new Vector3(0, 0, 0);

        line.AddRange(obstaclesObject);
        line.AddRange(cleansTranchesObject);


        Utils.Shuffle<GameObject>(line);

        //Start tranche
        GenerateClean(coordinate);

        //+1 Because we start at index, first tranche it's alway Start point
        for (i = 1; i < line.Count + 1; i++)
        {
            coordinate = new Vector3(0, 0, Constantes.SizeTranche * i);
            GameObject.Instantiate(line[i - 1], coordinate, Quaternion.identity);
        }

        //End Tranche
        GenerateEnd(new Vector3(0, 0, Constantes.SizeTranche * i));
    }

    private List<GameObject> PickObstacles(int number)
    {
        var obstacles = new List<GameObject> { };
        var random = 0;

        for(var i = 0; i < number; i++)
        {
            random = Random.Range(0, this.obstacles.Count);
            Debug.Log(random);
            obstacles.Add(this.obstacles[random]);
        }

        return obstacles;
    }

    private List<GameObject> CleanTranches(int number)
    {
        var tranches = new List<GameObject> { };

        for(var i = 0; i < number; i++)
        {
            tranches.Add(start);
        }

        return tranches;
    }

    public void GenerateClean(Vector3 coordinate)
	{
        GameObject.Instantiate(start, coordinate, Quaternion.identity);
    }

    public void GenerateEnd(Vector3 coordinate)
    {
        GameObject.Instantiate(end, coordinate, Quaternion.identity);
    }

    public void GenerateBigObstacleLeft(Vector3 coordinate)
    {
        GameObject.Instantiate(bigObstacleLeft, coordinate, Quaternion.identity);
    }
}

