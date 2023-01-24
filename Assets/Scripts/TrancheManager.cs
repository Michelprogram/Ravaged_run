using UnityEngine;
using System.Collections;

public class TrancheManager
{
    private GameObject start, bigObstacleLeft, rightObstacle,botObstacle, topObstacle,end, middleObstacle ;

    public TrancheManager(GameObject start, GameObject end, GameObject bigObstacleLeft, GameObject rightObstacle,GameObject botObstacle, GameObject topObstacle, GameObject middleObstacle) {
        this.start = start;
        this.end = end;
        this.bigObstacleLeft = bigObstacleLeft;
        this.rightObstacle = rightObstacle;
        this.botObstacle = botObstacle;
        this.topObstacle = topObstacle;
        this.middleObstacle = middleObstacle;
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

