using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    protected static GameManager gameManager;

    private void Awake()
    {
        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PickUpAnimation();
            PickUpItem();
            Destroy(gameObject);
        }
    }

    protected abstract void PickUpItem();

    protected abstract void PickUpAnimation();

    

}
