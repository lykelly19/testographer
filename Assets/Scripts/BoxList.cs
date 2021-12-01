using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxList
{
    Box[] boxes;
    int hlIndex; // index of currently highlighted box

    public BoxList()
    {
        hlIndex = -1;
        populateList();
    }

    // Reads data from file at filePath and populates BoxList with it
    private void populateList()
    {
        // each box has a public id
        Box[] boxes = Object.FindObjectsOfType<Box>();

        // retrieve the location of each box
        foreach (Box b in boxes)
        {
            b.X = b.transform.position.x;
            b.Y = b.transform.position.y;
        }

    }
    // updates Box highlight styling based on location
    public void updateHighlight(float posX, float posY)
    {
        if (hlIndex >= 0)
        {
            boxes[hlIndex].unHighlight();
        }
        int newH = findLocationMatch(posX, posY);

        if (newH >= 0 && newH < boxes.Length)
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
        for(int i = 0; i < boxes.Length; i++)
        {
            float xDif = System.Math.Abs(posX - boxes[i].X);
            float yDif = System.Math.Abs(posY - boxes[i].Y);

            // Check if within certain radius
            // FIXME: pick a radius that makes sense. 0.1 was just a guess.
            if(xDif < 0.1 && yDif < 0.1)
            {
                return i;
            }
        }

        return -1;
    }

    public string findBoxMatch(Vector2 position)
    {
        int index = findLocationMatch(position.x, position.y);

        if(index >= 0 && index < boxes.Length)
        {
            return boxes[index].name;
        }

        return null;
    }

    // Resets Boxlist back to its original state.
    public void reset()
    {
        // C# handles memory destruction for us, dont need to worry about old list.
        boxes = System.Array.Empty<Box>();
        hlIndex = -1;
        populateList();
    }
}
