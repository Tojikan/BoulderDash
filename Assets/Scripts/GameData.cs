using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>Contains the distance of the playear run and the distance to boulder </summary>
/// Static data class meant to be accessible form multiple functions. This contains all of the data in regards to a single run of the game
/// Distance tracks how far the player has run. Incremented in AutoScroll
/// BoulderDist is the stop meter that tracks how long the player has stopped. Increment/Decremented in player controller
public static class GameData
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
    }                           //setter in order to set the distance counter text
    public static float Distance
    {
        get { return distance; }
    }                               //accessor to read the distance
    public static Text distanceCounter;                           //This UI text component is set in Game Manager's awake function

    private static float boulderDist = 0f;                        //Meter that tracks how long you've stopped for. Should go from 0 to 1.0 as a float 
    public static float BoulderDist
    {
        get { return boulderDist; }
    }                           //Accessor to read the boulder dist
    private static float decreaseRate = 0.005f;                  //rate at which the boulder gets closer to player
    private static float increaseRate = 0.001f;                  //rate at which the boulder gets further from player

    #region distance
    public static void ResetDistance()
    {
        DistanceSet = 0;
    }

    public static void IncreaseDistance()
    {
        DistanceSet += .1f;
    }
    #endregion


    #region boulder distance

    public static void ResetStopMeter()
    {
        boulderDist = 0;
        decreaseRate = 0.005f;
        increaseRate = 0.001f;
    }

    /// <summary>Cause the boulder to get closer to the player </summary>
    public static void DecreaseBDist()
    {
        if (boulderDist >= 1)
            return;
        boulderDist += decreaseRate;
    }

    /// <summary> Cause the boulder to move further away from player </summary>
    public static void IncreaseBDist()
    {
        if (boulderDist <= 0)
            return;
        boulderDist -= increaseRate;
    }

    #endregion
}
