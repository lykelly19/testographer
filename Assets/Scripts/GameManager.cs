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
    Map currentMap = null;
    Score score = null;
    int highScore = 0;
    public Text endScoreText;
    public Text gameScoreText;
    public Text highScoreText;

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
        chosenDifficulty = -1;
    }

    /*
    Function to call from the level menu to choose level.
    Input: the level, an integer
    Result: chosenDifficulty = level
    */
    public void chooseDifficulty(int level) 
    {
        if(level >= 0 && level <= 1) { // Make sure is valid level
            FindObjectOfType<DataManager>().difficulty = level;
            chosenDifficulty = level;
        } else
        { // Not a valid level.
            Console.WriteLine("Error, invalid level in chooseDifficulty. Exiting . . .");
            System.Environment.Exit(-1);
        }
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

    // Does everything the game needs to do in a single frame.
    void playGame()
    {
        currentMap = FindObjectOfType<Map>();
        score = FindObjectOfType<Score>();
        gameScoreText.text = "Score: " + System.Convert.ToString(score.CurrentScore);

        currentMap.OnEndGame = (Timer timer) =>
        {
            float elapsedSeconds = timer.getElapsedSeconds();

            chosenDifficulty = FindObjectOfType<DataManager>().difficulty;

            score.calculateFinalScore((int)elapsedSeconds, chosenDifficulty);

            // update high score
            if (score.CurrentScore > FindObjectOfType<DataManager>().highScore)
            {
                highScore = score.CurrentScore;
                FindObjectOfType<DataManager>().highScore = score.CurrentScore;
            }

            FindObjectOfType<DataManager>().finalScoreText = score.getEndScoreDisplay();

            // move to end page
            SceneManager.LoadScene("EndMenu");
        };

        currentMap.OnUpdateScore = (bool isMatch) =>
        {
            score.updateScore(isMatch);
            if(score.CurrentScore > highScore)
            {
                highScore = score.CurrentScore;
            }
        };

        currentMap.updateIsDroppedCallback();

        // set up the back button to redirect back to start menu
        Button btn = GameObject.FindGameObjectsWithTag("Button")[0].GetComponent<Button>();
        btn.onClick.AddListener(delegate { changeScene("StartMenu"); });
    }

    // Start is called before the first frame update.
    // Required by Unity for this object.
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);  // set screen width & height

        if(!FindObjectOfType<DataManager>()) {
            GameObject gObj = new GameObject("Data Manager"); 
            gObj.AddComponent<DataManager>();
        }

        Text[] texts = FindObjectsOfType<Text>();
        foreach(Text t in texts)
        {
            if (t.name == "HighScoreDisplay")
            {
                highScoreText = t;
                highScoreText.text = "High Score: " + System.Convert.ToString(FindObjectOfType<DataManager>().highScore);
                break;
            }
        }
    }

    // Update is called once per frame.
    // Required by Unity for this object.
    void Update()
    {
        if (score != null) {
            gameScoreText.text = "Score: " + System.Convert.ToString(score.CurrentScore);
        }

        if ((FindObjectsOfType<Score>().Length > 0 || FindObjectsOfType<Map>().Length > 0)
            && currentMap == null)
        {
            playGame();
        }


        // display end scene text
        if(SceneManager.GetActiveScene().name == "EndMenu") 
        {
            Text[] texts = FindObjectsOfType<Text>();
            foreach (Text t in texts) {
                if(t.name == "Subtitle")
                {
                    t.text = FindObjectOfType<DataManager>().finalScoreText;
                }
            }
        }
    }
}
