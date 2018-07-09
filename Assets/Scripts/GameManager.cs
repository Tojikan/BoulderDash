using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Game Manager controls the state and flow of the game and will be responsible for game initiation
/// Also controls any changes to the UI overlay
/// </summary>
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
    public Image distMeter;                                         //drag in the distance meter image here
    private static Image s_distMeter;                               //static object reference to the distmeter
    public Text moneyCounter;                                       //drag in the text object for money counting
    public GameObject boulder;                                      //drag in the boulder game object
    private bool boulderDeath;                                      //you're dead if this is true

    private void Awake()
    {
        obstacleTimer = GetComponent<ObstacleTimer>();
        GameData.distanceCounter = distanceCounter;
        s_distMeter = distMeter;
    }

    private void Start()
    {
        InitGame();
    }

    #region game init
    //Start the timer
    void InitGame()
    {
        obstacleTimer.StartTimer();
        GameData.ResetDistance();
        GameData.ResetStopMeter();
        boulderDeath = false;
    }

    #endregion

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

        //if you exceed the stopping meter, start the boulder death
        if (GameData.BoulderDist >= 1)
        {
            boulderDeath = true;
        }

        //set the boulder dashing
        if (boulderDeath)
        {
            boulder.gameObject.SetActive(true);
            boulder.transform.Translate(0, -0.15f, 0);
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

    #region Game UI

    //grabs data from GameData to set the fill amount of the meter. static function because it's called in a few places. 
    public static void SetBDistMeter()
    {
        SetBDistColor(GameData.BoulderDist);
        s_distMeter.fillAmount = GameData.BoulderDist;
    }

    //set color of meter based on how full it is
    private static void SetBDistColor(float dist)
    {
        if (dist < 0.33)
        {
            s_distMeter.color = Color.green;
            return;
        }
        if (dist < 0.67 && dist > 0.33)
        {
            s_distMeter.color = Color.yellow;
            return;
        }
        if (dist >= 0.67)
        {
            s_distMeter.color = Color.red;
            return;
        }
        
    }


    public void SetMoneyCounter()
    {
        moneyCounter.text = GameData.Money.ToString("G3");
    }

    #endregion
}
