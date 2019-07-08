using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SimpleCoroutine : MonoBehaviour
{
    public UnityEvent StartEvent, OnEnableEvent, CoroutineEvent, EndCountDownEvent;
    public float StartHoldTime = 0;
    public float RepeatHoldTime = 1;
    public bool CanRun { private get; set; }

    private void Start()
    {
        StartEvent.Invoke();
    }

    private void OnEnable()
    {
        OnEnableEvent.Invoke();
    }

    public void OnStartCoroutine()
    {
        StartCoroutine( RunCoroutine() );
    }
     
    private IEnumerator RunCoroutine()
    {
        CanRun = true;
        yield return new WaitForSeconds(StartHoldTime);
        
        while (CanRun)
        {
            CoroutineEvent.Invoke();
            yield return new WaitForSeconds(RepeatHoldTime);
        } 
    }

    public int CountDownNum;
    
    public void CountDown()
    {
        CountDownNum--;
        if (CountDownNum <= 0)
        {
           EndCountDownEvent.Invoke();
        }
    }

    public void ResetCountDownNum(int num)
    {
        CountDownNum = num;
    }
}