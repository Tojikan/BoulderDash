using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Upon exiting a BG collider, it'll delete the collider and cycle in a new section
//Trashbin for removing BG colliders that are beyond the viewable area - position this object about half a BG section length above the game view
public class BGRemoval : MonoBehaviour
{
    public MapGenerator mapGenerator;                       //drag a reference to our map generator

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "BG")
        {
            //remove from the list storing active map sections
            mapGenerator.CurrentSections.Remove(other.gameObject);
            //then destroy it
            Destroy(other.gameObject);
            //Generate a new one
            mapGenerator.AddNewSection();
        }
    }
}
