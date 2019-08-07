using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ApplyForce : MonoBehaviour
{
    public GameObject SwipeInfo;
    public UnityEvent OnEnd;
    public Transform StartPoint;
    private Rigidbody rigid;
    public float force;
    public Vector3 Forces;
    public float HoldTime = 3;
    private Coroutine cr;
    private bool CanAddForce;
    private Vector3 StartSwipePosition;
    private Vector3 EndSwipePosition;
    private float SwipeLengthX;
    public float SwipeLengthY;
    public bool SwipingUp = false;
    public bool ballFollowFinger = false;
    public float StartShotTime;
    private float ShotTime;
    public float swipeTimeMax = 1.5f;
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
       
      
        
       // StartShotTime = Time.time;
        
        //ShotTime = Time.time - StartShotTime;
      
        ballFollowFinger = false;
        EndSwipePosition = Input.mousePosition;
        GetSwipeInfo();
        if (SwipingUp && CanAddForce)
        {

//            if (ShotTime < swipeTimeMax)
//            {
                transform.parent = null;
                rigid.AddForce(SwipeLengthX * force,SwipeLengthY * force ,SwipeLengthY * force);
           // }
            
            
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
        int direction;
        if (EndSwipePosition.x < StartSwipePosition.x)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }

        if(EndSwipePosition.y > StartSwipePosition.y)
        {
            SwipingUp = true;
        }
        else
        {
            SwipingUp = false;
        }
        SwipeLengthX = Mathf.Abs(EndSwipePosition.x - StartSwipePosition.x) * direction;
        SwipeLengthY = Mathf.Abs(EndSwipePosition.y - StartSwipePosition.y);
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
