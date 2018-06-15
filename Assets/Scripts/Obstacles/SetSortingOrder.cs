using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets the sorting order for sprites after it drops behind the y value of the player object
/// </summary>
public class SetSortingOrder : MonoBehaviour
{
    private static float playerY;
    private bool isSorted;

    //find the player if it hasn't been found yet. 
    private void Awake()
    {
        if (playerY == 0)
        {
            GameObject player = FindObjectOfType<PlayerController>().gameObject;
            playerY = player.transform.position.y + player.GetComponent<Collider2D>().offset.y;
        }
        isSorted = false;
    }

    private void Update()
    {
        if (!isSorted)
        {
            if (gameObject.transform.position.y > playerY)
            {
                gameObject.GetComponent<Obstacle>().SetLayer(5);
                isSorted = false;
            }
        }
    }
}
