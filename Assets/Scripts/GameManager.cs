using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//GameManager has a set of functions that let you control the state of the game
public class GameManager : MonoBehaviour
{
    public PlayerController player;                                 //drag reference to player controller
    public AutoScroll scroller;                                     //drag reference to scroller
    private ObstacleTimer obstacleTimer;                            //obstacleTimer should be a component on the same game object
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
    public Text distanceCounter;                                    //drag in the distance counter text here. GameManager sets up the reference but this is changed in the DistanceCounter script

    private void Awake()
    {
        obstacleTimer = GetComponent<ObstacleTimer>();
        DistanceCounter.distanceCounter = distanceCounter;
    }

    private void Start()
    {
        InitGame();
    }


    #region enable and disable movement


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
    #endregion

    //Start the timer
    void InitGame()
    {
        obstacleTimer.StartTimer();
    }

}
