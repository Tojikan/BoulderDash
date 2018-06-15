using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Specifically handles falling obstacles
/// Triggers an animation at a given time
/// </summary>
public class FallingObject : Obstacle
{
    //override of the setlayer method of Obstacle. Sets all child sorting layers to a given int
    public override void SetLayer(int layer)
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<SpriteRenderer>().sortingOrder = layer;
        }
    }

    protected override void TimerReceiver(int timerTime)
    {
        return;
    }


    protected override bool CheckZero()
    {
        return true;
    }
}
