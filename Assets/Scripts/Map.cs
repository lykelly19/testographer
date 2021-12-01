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

    public Map(string name)
    {
        mapName = name;

        // use the name to get the file path
        string sCurrentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
        string sFile = System.IO.Path.Combine(sCurrentDirectory, string.Format(@"..\\Resources\\MapData\\{0}.txt", name));
        string sFilePath = System.IO.Path.GetFullPath(sFile);

        regions = new RegionList(sFilePath);
        sidebarList = regions.generateSidebarList(10);
        boxes = new BoxList();
        score = new Score();
        timer = new Timer();
    }

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
}
