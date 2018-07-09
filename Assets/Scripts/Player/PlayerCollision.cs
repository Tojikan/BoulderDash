using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Handles death event
public class PlayerCollision : MonoBehaviour
{
    private PlayerController controller;                    //has the reference to scroller and animator

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lethal")
        {
            Debug.Log("Death");
            Death();
        }
    }

    //disable any scrolling
    private void Death()
    {
        controller.animator.SetTrigger("Death");
        controller.moveEnabled = false;
        controller.scroller.Death = true;
    }

    //resets the game after dying
    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
