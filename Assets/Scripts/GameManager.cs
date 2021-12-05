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
    Timer timer;
    int highScore = 0;
    public Text endScoreText;
    public Text gameScoreText;
    public Text highScoreText;

    GameObject gameCanvas;
    GameObject endMenu;

    bool gameOver = false;
    float elapsedSeconds;
    int currentScore;

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
        currentMap = FindObjectsOfType<Map>()[0];
        
        score = FindObjectsOfType<Score>()[0];
        Text[] texts = FindObjectsOfType<Text>();
        foreach (Text t in texts)
        {
            if(t.transform.name == "Score")
            {
                gameScoreText = t;
                gameScoreText.text = "Score: " + System.Convert.ToString(score.CurrentScore);
            }
        }

        GameObject[] roots = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject r in roots)
        {
            if (r.name == "EndMenu")
            {
                Debug.Log("Found EndMenu GameObject");
                endMenu = r;
                endMenu.SetActive(false);
            }
            if (r.name == "GameCanvas")
            {
                Debug.Log("Found GamePage Canvas");
                gameCanvas = r;
            }
        }

        

        currentMap.OnUpdateScore = (bool isMatch) =>
        {
            score.updateScore(isMatch);
            if(score.CurrentScore > highScore)
            {
                highScore = score.CurrentScore;
            }
        };

        currentMap.updateIsDroppedCallback();
    }

    public void calculateFinalScore()
    {
        // Set original score before bonus.
        int originalScore = currentScore;

        // Calculate time bonus.
        double logCalc;
        if (elapsedSeconds <= 1000)
        {
            logCalc = Math.Log(elapsedSeconds) * 1000;
        }
        else if (elapsedSeconds <= 0)
        {
            logCalc = 0;
        }
        else
        {
            logCalc = 3000;
        }
        int timeBonus = (3000 - (int)logCalc) / 10;

        // Calculate final score.
        // Multiplier is applied BEFORE time bonus is added.

        currentScore += Math.Abs(timeBonus);
        endScoreText.text = "Your Score: " + originalScore + " + " + timeBonus + " = " + currentScore;
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

        Text[] texts = FindObjectsOfType<Text>();
        foreach(Text t in texts)
        {
            if (t.name == "HighScoreDisplay")
            {
                highScoreText = t;
                highScoreText.text = "High Score: " + System.Convert.ToString(highScore);
                break;
            }
        }
    }

    // Update is called once per frame.
    // Required by Unity for this object.
    void Update()
    {
        if(timer)
        {
            elapsedSeconds = timer.getElapsedSeconds();
        }
        if(score)
        {
            currentScore = score.CurrentScore;
        }
        if (score != null) {
            gameScoreText.text = "Score: " + System.Convert.ToString(score.CurrentScore);
        }

        if ((FindObjectsOfType<Score>().Length > 0 || FindObjectsOfType<Map>().Length > 0)
            && currentMap == null)
        {
            Timer[] timers = FindObjectsOfType<Timer>();
            if(timers.Length > 0)
            {
                timer = timers[0];
            }
            playGame();
        }

        if(currentMap && currentMap.allMatched() && !gameOver)
        {
            

            Text[] texts = FindObjectsOfType<Text>();
            foreach (Text t in texts)
            {
                if(t.transform.name == "Subtitle")
                {
                    endScoreText = t;
                    calculateFinalScore();
                }
            }

            // move to end page
            endMenu.SetActive(true);
            gameCanvas.SetActive(false);
            currentMap.SetActive(false);

            gameOver = true;
        }
    }
}
