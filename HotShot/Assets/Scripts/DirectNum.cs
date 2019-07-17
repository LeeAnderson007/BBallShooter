using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectNum : MonoBehaviour
{

    public int value;
    
    
    

    // Update is called once per frame
    void Update()
    {
        //swipe right
        value++;
        //Swipe left
        value--;
        
        if (value > 3)
        {
            value = 0;
        }

        if (value < 0)
        {
            value = 3;
        }
        
        switch (value)
        {
            case 0:
                //
                break;
            case 1:
                //
                break;
            case 2:
                //
                break;
            case 3:
                //
                break;
        }
    }
}
