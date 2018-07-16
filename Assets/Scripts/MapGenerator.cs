using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//This class handles the generation of new map sections
//TO DO: add data sets for prefabs and add randomizer
public class MapGenerator : MonoBehaviour
{
    public List<GameObject> sectionPrefabs;                  //Drag all possible section prefabs here
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
            //randomizes a new prefab from list
            int randomIndex = UnityEngine.Random.Range(0, sectionPrefabs.Count);
            //instantiate a section and set its parent
            GameObject newSection = Instantiate(sectionPrefabs[randomIndex], position, Quaternion.identity, mapContainer.transform);
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
}
