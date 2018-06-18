using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Handles player input and controls
public class PlayerController : MonoBehaviour
{
    public AutoScroll scroller;                                                 //drag the object with the autoscroll here
    public float playerSideSpeed;                                               //the speed at which the character model moves from side to side
    private Animator animator;                                                  //animator component for setting animation parameters
    private bool isLaneChanging;                                                //check to see if player is currently in a movement to a different lane
    private Vector3 leftPos = new Vector3(-1.3f, 3.14f, 0);                     //left column position, passed into the movement coroutine.
    private Vector3 centerPos = new Vector3(0, 3.14f, 0);                       //center column position
    private Vector3 rightPos = new Vector3(1.3f, 3.14f, 0);                     //right column position  

    //enum definition storing possible player positions
    enum Positions
    {
        left,
        middle,
        right
    }                                                                                                     
    private Positions playerPosition;


    void Start()
    {
        //set initial center position
        transform.position = centerPos;
        playerPosition = Positions.middle;
        //initialize move check
        isLaneChanging = false;
        //get component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Stop movement upon receiving key down *temporary* and set idle animation
        if (Input.GetKey("down"))
        {
            IdleAnim();
            scroller.StopScroll();
            GameData.DecreaseBDist();
            GameManager.SetBDistMeter();
        }
        //otherwise resume walk as normal if key is not down
        else
        {
            StartWalkAnim();
            scroller.StartScroll();
        }
        
        //move left
        if (Input.GetKeyDown("left"))
        {
            if (isLaneChanging)
                return;
            MoveLeft();
        }

        //move right
        if (Input.GetKeyDown("right"))
        {
            if (isLaneChanging)
                return;
            MoveRight();
        }
    }

    //set animations using a animation bool parameter to prevent weird frame stuttering
    #region animations
    public void StartWalkAnim()
    {
        animator.SetBool("isWalking", true);
    }

    public void IdleAnim()
    {
        animator.SetBool("isWalking", false);
    }
    #endregion
    #region side movement
    //Left move function
    void MoveLeft()
    {
        //return if already left
        if (playerPosition == Positions.left)
        {
            return;
        }

        //if in the middle, move to the left
        if (playerPosition == Positions.middle)
        {
            StartCoroutine(SideMove(leftPos));
            playerPosition = Positions.left;

        }

        //or move to the middle if right
        if (playerPosition == Positions.right)
        {
            //transform.position = Vector3.Lerp(transform.position, centerPos, playerSideSpeed);
            StartCoroutine(SideMove(centerPos));
            playerPosition = Positions.middle;
        }
    }

    //same thing as above, but for moving right instead
    void MoveRight()
    {
        if (playerPosition == Positions.right)
        {
            return;
        }

        if (playerPosition == Positions.middle)
        {
            //transform.position = Vector3.Lerp(transform.position, rightPos, playerSideSpeed);
            StartCoroutine(SideMove(rightPos));
            playerPosition = Positions.right;
        }

        if (playerPosition == Positions.left)
        {
            //transform.position = Vector3.Lerp(transform.position, centerPos, playerSideSpeed);
            StartCoroutine(SideMove(centerPos));
            playerPosition = Positions.middle;
        }
    }

    //coroutine for smooth side movement. Accepts a parameter of target position to move to
    IEnumerator SideMove(Vector3 target)
    {
        //set bool
        isLaneChanging = true;
        //get the remaining distance between target and current position. Use sqrmagnitude to reduce computational needs
        float sqrRemainingDistance = (transform.position - target).sqrMagnitude;

        //loop continuously until we're close to target
        while (sqrRemainingDistance > float.Epsilon)
        {
            //Get a Vector3 that is between current and target based on sidemovement speed and time
            transform.position = Vector3.MoveTowards(transform.position, target, playerSideSpeed * Time.deltaTime);
            //recalculate remaining distance
            sqrRemainingDistance = (transform.position - target).sqrMagnitude;
            //continue without blocking the game loop
            yield return null;
        }
        //reset bool
        isLaneChanging = false;
    }
    #endregion
}
