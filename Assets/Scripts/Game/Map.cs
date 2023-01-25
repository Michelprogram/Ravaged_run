using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

public class Map
{
    private GameObject start, end,clean, bigObstacleLeft, rightObstacle,botObstacle, topObstacle, middleObstacle;

    private GameObject map;

    private List<GameObject> obstacles;

    private float speed;

    public Map(GameObject start, GameObject end, GameObject clean,GameObject bigObstacleLeft, GameObject rightObstacle,GameObject botObstacle, GameObject topObstacle, GameObject middleObstacle, GameObject map) {
        this.start = start;
        this.end = end;
        this.clean = clean;
        this.bigObstacleLeft = bigObstacleLeft;
        this.rightObstacle = rightObstacle;
        this.botObstacle = botObstacle;
        this.topObstacle = topObstacle;
        this.middleObstacle = middleObstacle;

        this.map = map;

        this.speed = InitMapSpeed();

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
        GenerateStart(coordinate);

        //+1 Because we start at index, first tranche it's alway Start point
        for (i = 1; i < line.Count + 1; i++)
        {
            coordinate = new Vector3(0, 0, Constantes.SizeTranche * i);
            var child = GameObject.Instantiate(line[i - 1], coordinate, Quaternion.identity, map.transform);
            child.name = "Tranche-" + i;
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
            obstacles.Add(this.obstacles[random]);
        }

        return obstacles;
    }

    private List<GameObject> CleanTranches(int number)
    {
        var tranches = new List<GameObject> { };

        for(var i = 0; i < number; i++)
        {
            tranches.Add(clean);
        }

        return tranches;
    }

    private void GenerateStart(Vector3 coordinate)
    {
        GameObject.Instantiate(start, coordinate, Quaternion.identity, map.transform);
    }

    private void GenerateEnd(Vector3 coordinate)
    {
        GameObject.Instantiate(end, coordinate, Quaternion.identity,map.transform);
    }

    private float InitMapSpeed()
    {

        switch (Shared.GetDifficulty())
        {
            default:
            case Shared.Difficulty.Easy:
                return Constantes.baseSpeed * 1;
            case Shared.Difficulty.Normal:
                return Constantes.baseSpeed * 2;
            case Shared.Difficulty.Hard:
                return Constantes.baseSpeed * 3;
            case Shared.Difficulty.Xtrem:
                return Constantes.baseSpeed * 4;
        }
    }


    public void MooveMap()
    {
        map.transform.Translate(Vector3.back * speed);
    }

}

