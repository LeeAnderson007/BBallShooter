using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeBehaviour : MonoBehaviour
{
    public UnityEvent OnChangeEvent;
    
    public void OnChange ()
    {
        OnChangeEvent.Invoke();
    }
}
