using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ApplyForce : MonoBehaviour
{
    public UnityEvent OnEnd;
    public Transform StartPoint;
    private Rigidbody rigid;
    public float force;
    public float HoldTime = 3;
    private Coroutine cr;
    private bool CanAddForce;
    private Vector3 StartSwipePosition;
    private Vector3 EndSwipePosition;
    private Vector3 tempV;
    private Vector3 newV;
    public float spacePoint = .35f;
    public bool SwipingUp;
    public bool ballFollowFinger;
    public float DistOfSwipe;
    
    private void Start()
    {
        CanAddForce = true;
        rigid = GetComponent<Rigidbody>();
        rigid.Sleep();
    }
    private void OnMouseDown()
    {
        var transform1 = transform;
        transform1.localPosition = Vector3.zero;
        transform1.localRotation = Quaternion.identity;
        StartSwipePosition = Input.mousePosition;
       
        ballFollowFinger = true;
    }
    private void OnMouseUp()
    {
        rigid.WakeUp();
        ballFollowFinger = false;
        EndSwipePosition = Input.mousePosition;
        GetSwipeInfo();
        if (SwipingUp && CanAddForce)
        {
            tempV = StartPoint.position;
            rigid.AddRelativeForce(Vector3.forward*(DistOfSwipe*force));
            rigid.AddRelativeForce(Vector3.up*(DistOfSwipe*force));
            transform.parent = null;
           
        }
        CanAddForce = false;
        SwipingUp = false;
        rigid.useGravity = true;
        RunEndForces();
    }
    public void FixedUpdate()
    {
        if (ballFollowFinger)
        {
            tempV.Set(Input.mousePosition.x, Input.mousePosition.y, spacePoint);
            transform.position = Camera.main.ScreenToWorldPoint(tempV);
        }
    }
    private void GetSwipeInfo()
    {
        if(EndSwipePosition.y > StartSwipePosition.y)
        {
            SwipingUp = true;
        }
        else
        {
            SwipingUp = false;
        }
        DistOfSwipe = Vector3.Distance(StartSwipePosition.normalized, EndSwipePosition.normalized);
    }
    private IEnumerator Hold()    
    {
        yield return new WaitForSeconds(HoldTime);
        rigid.Sleep();
        rigid.useGravity = false;
        var transformObj = transform;
        transformObj.parent = StartPoint.transform;
        transformObj.position = StartPoint.position;
        cr = null;
        CanAddForce = true;
        transformObj.localRotation = Quaternion.identity;
        OnEnd.Invoke();
    }

    public void RunEndForces()
    {
        if (cr == null)
        {
            cr = StartCoroutine(Hold());
        }
    }
}
