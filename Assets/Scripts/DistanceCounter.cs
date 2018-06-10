using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class DistanceCounter
{
    private static float distance = 0f;                            //distance variable to store how far 
    private static float DistanceSet
    {
        get { return distance; }
        set
        {
            distance = value;
            distanceCounter.text = distance.ToString("F1");
        }
    }                           //accessor in order to set the distance counter text
    public static float Distance
    {
        get { return distance; }
    }                               //accessor to read the distance
    public static Text distanceCounter;                           //for testing purposes

    public static void ResetDistance()
    {
        DistanceSet = 0;
    }

    public static void IncreaseDistance()
    {
        DistanceSet += .1f;
    }
}
