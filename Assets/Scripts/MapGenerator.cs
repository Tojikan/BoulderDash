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
    { get { return currentSections; }}              //public accessor for current sections list
    public GameObject mapContainer;                         //drag a reference to the map parent object
    private Vector3 lastSection;                            //Stores the position of the last section
    private const int sectionLimit = 5;                     //This is the amount of sections that exist on a map at a given time and at initialize

	// Use this for initialization
	void Start ()
    {
        currentSections = new List<GameObject>();
        InitialMapGeneration();
	}

    // Update is called once per frame
    void Update ()
    {
		
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
            position.y -= newSection.GetComponent<Collider2D>().bounds.size.y / 2;
        }
        //set our last section position
        lastSection = position;
    }

    //generate a new section, called by the BGRemoval class
    public void AddNewSection()
    {
        //spawn it at the last section position
        Vector3 newPosition = GetLastSectionPos();
        //Move it up by half since the sections have moved
        newPosition.y = newPosition.y / 2;
        //randomize new prefab
        int randomIndex = UnityEngine.Random.Range(0, sectionPrefabs.Count);
        //instantiate and set parent
        GameObject newSection = Instantiate(sectionPrefabs[randomIndex], newPosition, Quaternion.identity, mapContainer.transform);
        //add to section list
        currentSections.Add(newSection);
    }

    private Vector3 GetLastSectionPos()
    {
        return lastSection;
    }
}
