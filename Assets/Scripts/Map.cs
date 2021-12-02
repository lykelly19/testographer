using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    string mapName = null;
    int highScore = 0;
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

        // use the name to get the file path
        string sCurrentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
        string sFile = System.IO.Path.Combine(sCurrentDirectory, string.Format(@"..\\Resources\\MapData\\{0}.txt", name));
        string sFilePath = System.IO.Path.GetFullPath(sFile);

        regions = new RegionList(sFilePath, isDroppedCallback);
        sidebarList = regions.generateSidebarList(10);
        boxes = new BoxList();

        isDroppedCallback = (string id, Vector2 location) =>
        {
            string match = boxes.findBoxMatch(location);

            if (match == id)
            {
                // update score
                score.updateScore(true);

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
}
