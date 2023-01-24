using UnityEngine;
using UnityEngine.Events;
using System.Drawing;

public class Arrival : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Shared.arrival.Invoke();
    }
}

