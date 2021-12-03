using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // for changing scenes


public class GameManager : MonoBehaviour
{
    // Variable for when Map class is finished.
    int chosenDifficulty;
    Map currentMap;
    Score score;
    public Text endScoreText;

    public Map CurrentMap
    {
        get
        {
            return currentMap;
        }
    }

    // GameManager constructor.
    public GameManager()
    {
        // currentMap = new Map("UnitedStates", -1);
        chosenDifficulty = -1;
    }


    /*
    Function to call from the map menu to choose map.
    Input: the name of the map, which matches the name stored in one of the map objects.
    Result: chosenMap is updated
    */
    public void chooseMap() 
    {
        // change the scene to LevelMenu
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

        playGame();
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
        chooseMap();
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
        // Change scene to the game.
        SceneManager.LoadScene("GamePage");

        // score = FindObjectsOfType<Score>()[0];
        currentMap = FindObjectsOfType<Map>()[0];

        // Game stuff


        // code structure for checking high score & displaying message
        /*
        bool isHighScore;

        // check if high score
        if(currentScore > chosenMap.HighScore) {
            isHighScore = true;
        }

        if(isHighScore) {
            chosenMap.updateHighScore(); 
            displayHighScoreMessage();
        }
        */
    }

    public void displayEndScore()
    {
        int originalScore = score.OriginalScore;
        int levelMultiplier = score.LevelMultiplier;
        int timeBonus = score.TimeBonus;
        int finalScore = score.CurrentScore;
        endScoreText.text = "Your Score: " + originalScore + " x " + levelMultiplier + " + " + timeBonus + " = " + finalScore;
    }

    // displaying the high score message (code structure)
    /*
    public void displayHighScoreMesssage(GameObject highScoreObj) 
    {
        obj.SetActive(true);
    }
    */


    // Start is called before the first frame update.
    // Required by Unity for this object.
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);  // set screen width & height
    }

    // Update is called once per frame.
    // Required by Unity for this object.
    void Update()
    {
        // Debug.Log(SceneManager.GetActiveScene().name);
        // Stuff for every frame after the first frame.
    }
}
