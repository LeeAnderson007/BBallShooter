using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ApplyForce : MonoBehaviour
{

    public Transform StartPoint;
    private Rigidbody rigid;
    public Vector3 Forces;
    public float HoldTime = 3;
    private Coroutine cr;
    private bool CanAddForce;

    private void Start()
    {
        CanAddForce = true;
        rigid = GetComponent<Rigidbody>();
        rigid.Sleep();
    }

    private void OnMouseDown()
    {
        if (CanAddForce)
        {
            rigid.WakeUp();
            rigid.useGravity = true;
            rigid.AddForce(Forces);
        
            if (cr == null)
            {
                cr = StartCoroutine(Hold());
            }
        }
        CanAddForce = false;
    }

    private IEnumerator Hold()    
    {
        yield return new WaitForSeconds(HoldTime);
        rigid.useGravity = false;
        var transformObj = transform;
        transformObj.rotation = Quaternion.identity;
        transformObj.position = StartPoint.position;
        rigid.Sleep();
        cr = null;
        CanAddForce = true;
    }
}
