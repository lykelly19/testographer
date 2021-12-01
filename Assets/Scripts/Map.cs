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


    // CONSTRUCTOR
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
    /*
     * isDropped(string id, location) => void
     * String match = BoxList.findLocationMatch(location);
     * If (match == id)
     * If true: update score; regions.replaceRegion(); 
     * Since replaceRegion() replaced the Region at the appropriate spot in the list with a different one with a different location, this will hopefully also make the new Region appear and old Region disappear. If not, add functionality to do that.
     * // end game if all regions are matched
     * Else if (match == NULL): send label back to sidebar (animate sliding motion)
     * Else: update score; send label back to sidebar (animate sliding motion)

     * */

    public void isDropped(Vector2 location)
    {
        //string match = boxes.findBoxMatch(location);

    }

    public void reset()
    {
        mapName = "Map";
        highScore = 0;
    }
}
