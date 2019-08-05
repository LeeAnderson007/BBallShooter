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
    public float ShotTime;
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
        rigid.useGravity = true;
        ballFollowFinger = true;
        StartShotTime = Time.time;
        
    }
    private void OnMouseUp()
    {
        ShotTime = Time.time - StartShotTime;
        Debug.Log("Shot Time: " + ShotTime);
        ballFollowFinger = false;
        EndSwipePosition = Input.mousePosition;
        GetSwipeInfo();
        if (SwipingUp && CanAddForce)
        {

            if (ShotTime < .6f)
            {
                rigid.AddForce(SwipeLengthX * 1.5f,SwipeLengthY * 1.5f ,SwipeLengthY);
            }
            
            
            if (cr == null)
            {
                cr = StartCoroutine(Hold());
            }
        }
        CanAddForce = false;
        SwipingUp = false;
    }

    public void Update()
    {
        if (ballFollowFinger)
        {
            rigid.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, -StartPoint.position.z));
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
        rigid.useGravity = false;
        var transformObj = transform;
        transformObj.rotation = Quaternion.identity;
        transformObj.position = StartPoint.position;
        rigid.Sleep();
        cr = null;
        CanAddForce = true;
        OnEnd.Invoke();
    }
}
