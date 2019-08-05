using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ApplyTorque : MonoBehaviour
{
    public UnityEvent MouseDownEvent, OnTriggerEnterEvent;
    public Vector3 forces;
    private Rigidbody rb;
    
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ApplyTorqueToObject()
    {
        rb.AddTorque(forces);
    }

    private void OnMouseUp()
    {
       MouseDownEvent.Invoke(); 
    }
}
