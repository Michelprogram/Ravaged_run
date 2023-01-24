using UnityEngine;
using UnityEngine.Events;
using System.Drawing;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Shared.obstacle.Invoke();
    }
}

