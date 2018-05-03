using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//currently only lets you disable and enable the autoscroll and player controls
public class GameManager : MonoBehaviour
{
    public PlayerController player;                                 //drag reference to player controller
    public AutoScroll scroller;                                     //drag reference to scroller
    private bool enableMove;                                        //checks if we're enabled or not
    public bool EnableMove                                          //public property that calls the functions to enable or disable
    {
        get
        {
            return enableMove;
        }
        set
        {
            enableMove = value;
            if (!enableMove)
            {
                DisableMovement();
            }
            else
            {
                EnableMovement();
            }
        }
    }

    private void Update()
    {
        //for testing purposes, if you press space, we set the bool to true or false
        if (Input.GetKeyDown("space"))
        {
            if (enableMove)
                EnableMove = false;
            else
                EnableMove = true;
        }
    }

    //disables all movement and goes into idle animation
    void DisableMovement()
    {

        scroller.enabled = false;
        player.IdleAnim();
        player.enabled = false;
       
    }

    //enables all movement
    void EnableMovement()
    {
        player.enabled = true;
        scroller.enabled = true;
    }
}
