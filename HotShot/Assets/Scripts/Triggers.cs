using System;
using UnityEngine;
using UnityEngine.Events;

public class Triggers : MonoBehaviour
{

    public UnityEvent TriggerEnterEvent;

    public void OnTriggerEnter(Collider other)
    {
        TriggerEnterEvent.Invoke();
    }
}
