using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameActionHandler : MonoBehaviour
{
    public UnityEvent OnHandleEvent;
    public GameAction ActionHanlder;
    
    // Start is called before the first frame update
    void Start()
    {
        ActionHanlder.Raise += Raise;
    }

    private void Raise()
    {
        OnHandleEvent.Invoke();
    }
    
}
