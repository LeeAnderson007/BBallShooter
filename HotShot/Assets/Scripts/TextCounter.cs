using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCounter : MonoBehaviour
{
    private Text label;
    public int num = 3;
    public GameAction ActionHandler;
    public string words;
    
    // Start is called before the first frame update
    private void Start()
    {
        label = GetComponent<Text>();
        ActionHandler.Raise = OnHandle;
    }

    private void OnHandle()
    {
        label.text = num > 0 ? num.ToString() : words;
        num--;
    }
}