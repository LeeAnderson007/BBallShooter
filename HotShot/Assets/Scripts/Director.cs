using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Director : ScriptableObject
{

    public Worker North, South, East, West;

    public enum Directions
    {
        North,
        South,
        East,
        West
    }

    public Directions direction;


    public void Run()
    {
        switch (direction)
        {
            case Directions.North:
                North.Run();
                break;
            case Directions.South:
                Work(180);
                South.Run();
                break;
            case Directions.East:
                Work(0);
                break;
            case Directions.West:
                Work(0);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Work(int num)
    {
        //Work
        //
        //
        //
        
    }
}
