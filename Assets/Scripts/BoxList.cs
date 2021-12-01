using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxList
{
    List<Box> boxes;
    int hlIndex; // index of currently highlighted box

    public BoxList()
    {
        boxes = new List<Box>();
        hlIndex = -1;
        populateList();
    }

    // Reads data from file at filePath and populates BoxList with it
    private void populateList()
    {
        System.Console.WriteLine("FIXME: BoxList.populateList() does nothing!\n");
    }
    // updates Box highlight styling based on location
    public void updateHighlight(float posX, float posY)
    {
        if (hlIndex >= 0)
        {
            boxes[hlIndex].unHighlight();
        }
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
    private int findLocationMatch(float posX, float posY)
    {
        for(int i = 0; i < boxes.Count; i++)
        {
            float xDif = System.Math.Abs(posX - boxes[i].PosX);
            float yDif = System.Math.Abs(posY - boxes[i].PosY);

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
