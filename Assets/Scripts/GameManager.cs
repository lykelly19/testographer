using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // for changing scenes

public class GameManager : MonoBehaviour
{
    // Variable for when Map class is finished.
    // Map chosenMap;
    int chosenDifficulty;
    
    // GameManager constructor.
    public GameManager()
    {
        // When the game starts, this will be called to initialize the object.
        // Difficulty and Map will be set to placeholders to wait for input from the user.
        // chosenMap = null;
        chosenDifficulty = -1;
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
    public void chooseMap(string name) 
    {
        //Map newMap;
        /*
        1) Find the map m in the array/list/vector/whatever of maps where m.getName() == name
        2) Update chosenMap with m:

        selectMap(newMap);
        */
        // 3) change the scene to LevelMenu
        SceneManager.LoadScene("LevelMenu");
    }

    /*
    Function to call from the level menu to choose level.
    Input: the level, an integer
    Result: chosenDifficulty = level
    */
    public void chooseDifficulty(int level) 
    {
        if(level >= 0 && level <= 1) { // Make sure is valid level
            chosenDifficulty = level;
        } else
        { // Not a valid level.
            Console.WriteLine("Error, invalid level in chooseDifficulty. Exiting . . .");
            System.Environment.Exit(-1);
        }

        // Change scene to the game.
        SceneManager.LoadScene("GamePage");
    }

    // Loads the scene passed as parameter
    public void changeScene(string nextScene) 
    {
        SceneManager.LoadScene(nextScene);
    }

    // Quit/exit the game
    public void exitGame()
    {
        Application.Quit();
    }

    // Gets the new map and changes the scene.
    public void mapMenuOnClick(string nextScene, string mapName)
    {
        chooseMap(mapName);
        SceneManager.LoadScene(nextScene);
    }

    // Gets the difficulty and changes the scene.
    public void levelMenuOnClick(string nextScene, int level)
    {
        chooseDifficulty(level);
        SceneManager.LoadScene(nextScene);
    }

    // Does everything the game needs to do in a single frame.
    void playGame()
    {
        // Game stuff
    }

    // Start is called before the first frame update.
    // Required by Unity for this object.
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);  // set screen width & height

        // Stuff for FIRST FRAME ONLY.
    }

    // Update is called once per frame.
    // Required by Unity for this object.
    void Update()
    {
        // Stuff for every frame after the first frame.
    }
}
