using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GameAction : ScriptableObject
{
    public UnityAction Raise;
    
    public void OnRaise()
    {
        Debug.Log(Raise);
        Raise?.Invoke();
    }
}