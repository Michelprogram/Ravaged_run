using UnityEngine;
using System.Collections;

public class Start : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Shared.start.Invoke();
    }
}

