using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    string mapName = "Map";
    int highScore = 0;

    RegionList regions;
    List<Region> sidebarList;
    BoxList boxes;
    Score score;
    Timer timer;
    System.Action<string, Vector2> isDroppedCallback;

    // CONSTRUCTOR
    public Map(string name)
    {
        mapName = name;

        // use the name to get the file path
        string sCurrentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
        string sFile = System.IO.Path.Combine(sCurrentDirectory, string.Format(@"..\\Resources\\MapData\\{0}.txt", name));
        string sFilePath = System.IO.Path.GetFullPath(sFile);

        regions = new RegionList(sFilePath, isDroppedCallback);
        sidebarList = regions.generateSidebarList(10);
        boxes = new BoxList();
        score = new Score();
        timer = new Timer();

        isDroppedCallback = (string id, Vector2 location) =>
        {
            string match = boxes.findBoxMatch(location);

            if (match == null)
            {
                // FIXME: send box back to sidebar
            }
            else if (match == id)
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

                // check if game is over & end it if so
            }
            else
            {
                score.updateScore(false);

                // FIXME: send box back to sidebar
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
    
    public void reset()
    {
        mapName = "Map";
        highScore = 0;
    }
}
