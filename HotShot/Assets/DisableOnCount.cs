using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnCount : MonoBehaviour
{
    public float timer = 2;
    // Start is called before the first frame update
    private void Start()
    {
        Invoke(nameof(Disable), timer);
    }

    // Update is called once per frame
    private void Disable()
    {
        gameObject.SetActive(false);   
    }
}
