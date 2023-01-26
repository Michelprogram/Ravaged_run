using UnityEngine;
using UnityEngine.Events;
using System.Drawing;

public class Obstacle : MonoBehaviour
{
    public GameObject[] spawnBonus;

    public GameObject bonus;

    void Start()
    {
        SpawnRandomCoin();
    }

    void OnTriggerEnter(Collider other)
    {
        Shared.obstacle.Invoke();
    }

    private void SpawnRandomCoin()
    {
        var random = Random.Range(0, spawnBonus.Length - 1);

        var spawn = spawnBonus[random];

        GameObject.Instantiate(bonus, spawn.transform.position, Quaternion.identity);

    }
}

