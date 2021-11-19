using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapList
{
    List<Box> boxes;
    int hlIndex; // index of currently highlighted box

    /*
 constructor(string mapName) => BoxList
 Generates boxes from presets for each map
 Store presets elsewhere
 File? Stores data in specific format
 Based on mapName, decide which file to read from
 This way, algorithm to populate is the same every time, and we don’t have to hardcode a bunch of values and make a giant mess
 Should read from same file as RegionList to avoid contradictions
    */
    // updates Box highlight styling based on location
    public void updateHighlight(int posX, int posY)
    {
        boxes[hlIndex].unHighlight();
        int newH = findLocationMatch(posX, posY);

        if (newH >= 0 && newH < boxes.Count)
        {
            boxes[newH].highlight();
        }
    }

    /*
     * Searches list for a Box with a matching location
     * If found: return index
     * If DNE: return -1
    */
    private int findLocationMatch(int posX, int posY)
    {
        for(int i = 0; i < boxes.Count; i++)
        {
            int xDif = System.Math.Abs(posX - boxes[i].PosX);
            int yDif = System.Math.Abs(posY - boxes[i].PosY);

            // Check if within certain radius
            // FIXME: pick a radius that makes sense. 0.1 was just a guess.
            if(xDif < 0.1 && yDif < 0.1)
            {
                return i;
            }
        }

        return -1;
    }

}
