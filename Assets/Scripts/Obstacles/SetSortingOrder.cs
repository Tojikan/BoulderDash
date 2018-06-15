using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets the sorting order for sprites after it drops behind the y value of the player object
/// </summary>
public class SetSortingOrder : MonoBehaviour
{
    private static float playerY = 0;               //static float that stores the y position of the player
    private bool isSorted;                          //bool check to see if this has already been sorted

    //find the player if it hasn't been found yet. 
    private void Awake()
    {
        //Find the playerY for the first time
        if (playerY == 0)
        {
            // Find Player and get the Y position
            GameObject player = FindObjectOfType<PlayerController>().gameObject;
            playerY = player.transform.position.y + player.GetComponent<Collider2D>().offset.y;
        }
        isSorted = false;
    }

    private void Update()
    {
        //check if sorted
        if (!isSorted)
        {
            //then set the obstacle's sorting layer
            if (gameObject.transform.position.y > playerY)
            {
                gameObject.GetComponent<Obstacle>().SetLayer(5);
                isSorted = false;
            }
        }
    }
}
