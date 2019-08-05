using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeInfoManager : MonoBehaviour
{
    
    public Vector3 SwipeFingerDownPosition;
    public Vector3 SwipeFingerUpPosition;
    public bool CanSwipe = false;
    private bool SwipingUp;
    private bool SwipingRight;
    private bool SwipingLeft;
    private float SwipeDistY;
    public float SwipeX;
    public float SwipeY;
    private float SwipeDistX;
   

   

    void Update()
    {
        foreach (var touch in Input.touches)
        {
            if (CanSwipe = false)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    SwipeFingerUpPosition = touch.position;
                    SwipeFingerDownPosition = touch.position;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    SwipeFingerUpPosition = touch.position;
                }
                SwipeDirectionChecker(SwipeFingerDownPosition, SwipeFingerUpPosition);
                if (SwipingUp)
                {
                    SwipeDistChecker(SwipeFingerDownPosition, SwipeFingerUpPosition);
                }

                if (SwipingRight)
                {
                    SwipeX = SwipeDistX;
                    SwipeY = SwipeDistY;
                }
                else if (SwipingLeft)
                {
                    SwipeX = -SwipeDistX;
                    SwipeY = SwipeDistY;
                }

                CanSwipe = true;
                ResetShotChecker();
            }
            ShowInfo();
        }
    }
    public void SwipeDirectionChecker(Vector3 Pos1, Vector3 Pos2)
    {
        if (Pos1.y < Pos2.y)
        {
            SwipingUp = true;
            
            
            if (Pos1.x < Pos2.x)
            {
                SwipingRight = true;
            }
            else
            {
                SwipingLeft = true;
            }
        }
    }
    public void SwipeDistChecker(Vector3 Pos1, Vector3 Pos2)
    {
        SwipeDistX = Mathf.Abs(Pos2.x - Pos1.x);
        SwipeDistY = Mathf.Abs(Pos2.y - Pos1.y);
    }
    public void ResetShotChecker()
    {
        SwipingUp = false;
        SwipingRight = false;
        SwipingLeft = false;
        CanSwipe = true;
        
    }

    public void ShowInfo()
    {
        Debug.Log("SwipeInfo X: " + SwipeX + " Y: " + SwipeY );
    }
}
    