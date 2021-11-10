using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // for changing scenes

public class GameManager : MonoBehaviour
{
    // Variables for when View, and Map classes are complete.
    /* 
    View myView;
   
    Map chosenMap;
    */
    // there is no difficulty class, just an int
    int chosenDifficulty = -1;
    
    // GameManager constructor.
    public GameManager()
    {
        // When the game starts, this will be called to initialize the object.
        // The View will be set to the main menu.
        // Difficulty and Map will be set to null to wait for input from the user.
        /*
        myView = (Whatever the main menu is);
        chosenDifficulty = null;
        chosenMap = null;
        */
    }

    // Changes the current map to parameter m.
    // Commented out until Map class is finished.
    /*
    private void selectMap(Map m) { chosenMap = m; }
    */

    /*
    Function to call from the map menu to choose map.
    Input: the name of the map, which matches the name stored in one of the map objects.
    Result: chosenMap is updated
    */
    public void chooseMap(string name) {
        //Map newMap;
        /*
        1) Find the map m in the array/list/vector/whatever of maps where m.getName() == name
        2) Update chosenMap with m:

        selectMap(newMap);
        */
    }

    /*
    Function to call from the level menu to choose level.
    Input: the level, an integer
    Result: chosenDifficulty = level
    */
    public void chooseDifficulty(int level) {
        if(level >= 0 && level <= 1) { // make sure is valid level
            chosenDifficulty = level;
        }
    }

    // Changes the current difficulty to parameter d.
    // Commented out until Difficulty class is finished.
    /*
    private void selectDifficulty(Difficulty d) { chosenDifficulty = d; }
    */

    // Does everything the game needs to do in a single frame.
    void playGame()
    {
        // Game stuff
    }

    // Start is called before the first frame update.
    // Required by Unity for this object.
    void Start()
    {
        // Stuff for FIRST FRAME ONLY.
    }

    // Update is called once per frame.
    // Required by Unity for this object.
    void Update()
    {
        // Stuff for every frame after the first frame.
    }
}
