using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//This class handles the generation of new map sections
//TO DO: add data sets for prefabs and add randomizer
public class MapGenerator : MonoBehaviour
{
    public List<GameObject> sectionPrefabs;                  //Drag all possible section prefabs here
    public bool maxPickup;                                  //So we can set pickups to 100% spawn rate
    public GameObject testPickup;                            //Drag a pickup prefab here
    private List<GameObject> currentSections;                //stores all the current sections in the game
    public List<GameObject> CurrentSections
    { get { return currentSections; }}                      //public accessor for current sections list
    public GameObject mapContainer;                         //drag a reference to the map parent object
    private Vector3 lastSection;                            //Stores the position of the last section
    private const int sectionLimit = 5;                     //This is the amount of sections that exist on a map at a given time and at initialize

	// Use this for initialization
	void Start ()
    {
        currentSections = new List<GameObject>();
        InitialMapGeneration();
	}

    //Generates the initial map
    private void InitialMapGeneration()
    {
        //position placeholder variable
        Vector3 position = new Vector3(0, 0, 0);
        //creates new sections up to sectionLimit
        for (int i = 0; i < sectionLimit; i++)
        {
            //initialized index at 0 so we don't start with obstacles
            int randomIndex = 0;
            if (i > 1)
            {
                //randomizes a new prefab from list
                randomIndex = UnityEngine.Random.Range(0, sectionPrefabs.Count);
            }
            //instantiate a section and set its parent
            GameObject newSection = Instantiate(sectionPrefabs[randomIndex], position, Quaternion.identity, mapContainer.transform);
            //add pickups
            GeneratePickups(newSection);
            //add to our section list
            currentSections.Add(newSection);
            //set a new position for the next section, half of the box collider
            position.y -= newSection.GetComponent<Collider2D>().bounds.size.y;
        }
        //set our last section position
        lastSection = position;
    }

    //generate a new section, called by the BGRemoval class
    public void AddNewSection()
    {
        //Get a new position based on the last section
        Vector3 newPosition = GetNewSectionPos();
        //randomize new prefab
        int randomIndex = UnityEngine.Random.Range(0, sectionPrefabs.Count);
        //instantiate and set parent
        GameObject newSection = Instantiate(sectionPrefabs[randomIndex], newPosition, Quaternion.identity, mapContainer.transform);
        //add to section list
        currentSections.Add(newSection);
        GeneratePickups(newSection);
    }

    //gets the position for a new section
    private Vector3 GetNewSectionPos()
    {
        //gets the last section
        GameObject lastSection = currentSections[sectionLimit-1];
        Vector3 newSectionPosition = lastSection.transform.position;
        //adds the size of the collider to the y position since everything has moved roughly one whole space
        newSectionPosition.y -= lastSection.GetComponent<Collider2D>().bounds.size.y;
        return newSectionPosition;
    }

    //generates pickups at random
    private void GeneratePickups(GameObject section)
    {
        Vector3 pickupPosition;
        //get random int and if over 70, generate the pickup
        int random;
        if (!maxPickup)
            random = UnityEngine.Random.Range(0, 101);
        else 
            random = UnityEngine.Random.Range(70, 101);

        if (random >= 70)
        {
            //random lane positions for the pickup. Obtained old fashion style so may need to be changed to be more dynamic later depending
            if (random <= 80)
                pickupPosition = new Vector3(-4.38f, 0, 0);
            else if (random <= 90)
                pickupPosition = new Vector3(-2.87f, 0, 0);
            else
                pickupPosition = new Vector3(-1.37f, 0, 0);
            
            //instantiate a new pickup and set its parent accordingly
            GameObject newPickup = Instantiate(testPickup, pickupPosition, Quaternion.identity);
            newPickup.transform.SetParent(section.transform, false);
        }
    }
}
