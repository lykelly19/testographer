using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // for changing scenes

public class GameManager : MonoBehaviour
{
    // Variables for when View, Difficulty, and Map classes are complete.
    /* 
    View myView;
    Difficulty chosenDifficulty;
    Map chosenMap;
    */
    
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
