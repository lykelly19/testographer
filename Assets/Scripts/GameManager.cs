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
    int highScore = 0;
    public Text endScoreText;
    public Text gameScoreText;

    bool isPlaying;

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
    async public void chooseDifficulty(int level) 
    {
        if(level >= 0 && level <= 1) { // Make sure is valid level
            chosenDifficulty = level;
        } else
        { // Not a valid level.
            Console.WriteLine("Error, invalid level in chooseDifficulty. Exiting . . .");
            System.Environment.Exit(-1);
        }

        StartCoroutine(loadGamePage());
        //SceneManager.LoadScene("GamePage");
        playGame();
    }

    IEnumerator loadGamePage()
    {
        Debug.Log("loadGamePage called");
        AsyncOperation loadMap = SceneManager.LoadSceneAsync("GamePage");
        Debug.Log("isDone: " + loadMap.isDone);
        while (!loadMap.isDone)
        {
            Debug.Log("loadGamePage while loop entered: " + loadMap.isDone);
            yield return null;
        }
        Debug.Log("Calling playGame()");
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

    // Does everything the game needs to do in a single frame.
    void playGame()
    {
        currentMap = FindObjectsOfType<Map>()[0];

        // Change scene to the game.
        Debug.Log("Finding Score object");
        score = FindObjectsOfType<Score>()[0];

        gameScoreText.text = "Score: " + System.Convert.ToString(score.CurrentScore);

        currentMap.OnEndGame = (Timer timer) =>
        {
            float elapsedSeconds = timer.getElapsedSeconds();
            score.calculateFinalScore((int)elapsedSeconds, chosenDifficulty);

            // update high score
            if (score.CurrentScore > highScore)
            {
                highScore = score.CurrentScore;
            }

            isPlaying = false;

            // move to end page
            SceneManager.LoadScene("EndMenu");
        };

        currentMap.OnUpdateScore = (bool isMatch) =>
        {
            score.updateScore(isMatch);
        };

        currentMap.updateIsDroppedCallback();

        isPlaying = true;

        Debug.Log("End of playGame function");
    }


    public void setEndScore()
    {
        endScoreText.text = score.getEndScoreDisplay();
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
        if(isPlaying)
        {
            gameScoreText.text = "Score: " + System.Convert.ToString(score.CurrentScore);
        }
        // Debug.Log(SceneManager.GetActiveScene().name);
        // Stuff for every frame after the first frame.
    }
}
