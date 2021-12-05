using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxList
{
    Box[] boxes;
    int level;
    // FIXME: list of key-value pairs with id as the key and abbreviation as the value

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

    public BoxList(int difficulty)
    {
        populateList();
        level = difficulty;
    }

    // Reads data from file at filePath and populates BoxList with it
    public void populateList()
    {
        // each box has a public id
        boxes = Object.FindObjectsOfType<Box>();

        // retrieve the location of each box
        foreach (Box b in boxes)
        {
            b.X = b.transform.position.x;
            b.Y = b.transform.position.y;
            b.Level = level;
        }
    }

    // Function is called when a match happens.
    // If so, this will update the box's label so
    // it will display the full name of the region.
    public void updateBoxLabel(string name)
    {
        for(int i = 0; i < boxes.Length; i++)
        {
            if(boxes[i].name == name)
            {
                boxes[i].Label = boxes[i].name;
                break;
            }
        }
    }

    public void SetActive(bool isActive)
    {
        foreach (Box b  in boxes)
        {
            b.gameObject.SetActive(isActive);
        }
    }

    // /*
    //  * Searches list for a Box with a matching location
    //  * If found: return index
    //  * If DNE: return -1
    // */
    private int findLocationMatch(float posX, float posY)
    {
        for(int i = 0; i < boxes.Length; i++)
        {
            float xDif = System.Math.Abs(posX - boxes[i].X);
            float yDif = System.Math.Abs(posY - boxes[i].Y);

            // Check if within certain radius
            // FIXME: pick a radius that makes sense. 0.1 was just a guess.
            if(xDif < 0.4 && yDif < 0.4)
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

    // // Resets Boxlist back to its original state.
    // public void reset()
    // {
    //     boxes = System.Array.Empty<Box>();
    //     hlIndex = -1;
    //     populateList();
    // }

}
