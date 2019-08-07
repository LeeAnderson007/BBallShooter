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
        StartSwipePosition = Input.mousePosition;
        rigid.WakeUp();
        ballFollowFinger = true;
    }
    private void OnMouseUp()
    {
        ballFollowFinger = false;
        EndSwipePosition = Input.mousePosition;
        GetSwipeInfo();
        if (SwipingUp && CanAddForce)
        {
            transform.parent = null;
            rigid.AddForce(0,DistOfSwipe * force , DistOfSwipe * force * 1.3f);
            if (cr == null)
            {
                cr = StartCoroutine(Hold());
            }
        }
        CanAddForce = false;
        SwipingUp = false;
        rigid.useGravity = true;
    }
    public void Update()
    {
        if (ballFollowFinger)
        {
            rigid.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, transform.position.z));
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
        transform.parent = StartPoint.transform;
        transformObj.rotation = Quaternion.identity;
        transformObj.position = StartPoint.position;
        cr = null;
        CanAddForce = true;
        OnEnd.Invoke();
    }
}
