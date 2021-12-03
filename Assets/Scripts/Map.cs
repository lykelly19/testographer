using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{

    /*
    string mapName = null;
    public int highScore = 0;
    int level;
    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

    RegionList regions;
    List<Region> sidebarList;
    BoxList boxes;
    public Score score;
    Timer timer;
    System.Action<string, Vector2> isDroppedCallback;

    // CONSTRUCTOR
    public Map(string name, int difficulty)
    {
        mapName = name;
        level = difficulty;

        regions = new RegionList("temp", isDroppedCallback);
        //sidebarList = regions.generateSidebarList(10);
        boxes = new BoxList(level);

        isDroppedCallback = (string id, Vector2 location) =>
        {
            string match = boxes.findBoxMatch(location);

            if (match == id)
            {
                // update score
                score.updateScore(true);

                // update box label
                boxes.updateBoxLabel(id);

                // replace with unmatched region
                int index = -1;
                for (int i = 0; i < sidebarList.Count; i++)
                {
                    if (sidebarList[i].Id == id)
                    {
                        index = i;
                    }
                }
                regions.replaceRegion(sidebarList, index);

                // check if game is over & end it if so:
                if (regions.checkAllMatched())
                {
                    // calculate final score
                    float elapsedSeconds = timer.getElapsedSeconds();
                    score.calculateFinalScore((int)elapsedSeconds, level);

                    // update high score
                    if (score.currentScore > highScore)
                    {
                        highScore = score.currentScore;
                    }

                    // move to end page
                    SceneManager.LoadScene("EndMenu");
                }
            }
            else
            {
                score.updateScore(false);
            }
        };

    }

    // GETTERS AND SETTERS
    public string MapName
    {
        get
        {
            return mapName;
        }

        set
        {
            mapName = value;
        }
    }

    public int HighScore
    {
        get
        {
            return highScore;
        }

        set
        {
            highScore = value;
        }
    }

    // METHODS

    public void populate()
    {
        boxes.populateList();
        Timer[] timers = Object.FindObjectsOfType<Timer>();
        timer = timers[0];
        Score[] scores = Object.FindObjectsOfType<Score>();
        score = scores[0];
    }
    
    public void reset()
    {
        regions.reset();
        boxes.reset();
        mapName = null;
    }
    */
}
