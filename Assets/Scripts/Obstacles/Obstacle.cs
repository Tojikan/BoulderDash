using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base Class for Obstacles
public class Obstacle : MonoBehaviour
{
    public bool showBox;
    public int triggerTime;
    public int loopLength;
    
    #region On Enable and Disable
    //subscribes to the timer event upon enable
    protected virtual void OnEnable()
    {
        //Check if the loop time is valid
        if (CheckZero() == false)
            Destroy(gameObject);
        ObstacleTimer.ObsTimerEvent += TimerReceiver;
    }

    //makes sure we are unsubscribed from the timer
    protected virtual void OnDisable()
    {
        ObstacleTimer.ObsTimerEvent -= TimerReceiver;
    }
    #endregion

    #region Obstacle main functions
    //Destroys the obstacle
    public virtual void DestroyObstacle()
    {
        ObstacleTimer.ObsTimerEvent -= TimerReceiver;
        Destroy(gameObject);
    }

    //Triggers obstacle at the time. Takes in a parameter of current time
    protected virtual void TimerReceiver(int timerTime)
    {
        if ((timerTime % loopLength) == timerTime)
        {
            TriggerObstacle();
        }
    }

    //to be implemented in the inherited obstacle classes
    protected virtual void TriggerObstacle() { }

    //sets the sorting layer for sprites based on a given int. To be implemented in inherited classes
    public virtual void SetLayer(int layer)
    {
    }


    #endregion

    #region utility functions and helpers
    //Used to draw big red boxes over the area of the collider. For use in editing/creating sections
    private void OnDrawGizmos()
    {
        if (showBox == true)
        {
            Gizmos.color = Color.red;
            BoxCollider2D boundary = GetComponent<BoxCollider2D>();
            Gizmos.DrawCube(transform.position, boundary.size);
        }
    }

    //Checks if the length of the loop is zero, which is invalid
    protected virtual bool CheckZero()
    {
        if (loopLength == 0)
        {
            Debug.Log("Invalid loop length.");
            return false;
        }
        return true;
    }
    #endregion
}
