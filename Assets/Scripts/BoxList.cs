using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxList
{
    List<Box> boxes;
    int hlIndex; // index of currently highlighted box
    string filePath;

    public BoxList(string path)
    {
        boxes = new List<Box>();
        filePath = path;
        hlIndex = -1;
        populateList();
    }

    // Reads data from file at filePath and populates BoxList with it
    private void populateList()
    {
        System.Console.WriteLine("FIXME: BoxList.populateList() is untested!\n");

        if (!System.IO.File.Exists(filePath))
        {
            // Open the file to read from.
            using (System.IO.StreamReader sr = System.IO.File.OpenText(filePath))
            {
                string dataString;
                while ((dataString = sr.ReadLine()) != null)
                {
                    string[] data = dataString.Split();
                    // DELETE ME: testing info print statement
                    System.Console.WriteLine("data[0]: {0}; data[1]: {1}; data[2]: {2}\n", data[0], data[1], data[3]);

                    if (data.Length == 3)
                    {
                        boxes.Add(new Box() { Id = data[0], PosX = float.Parse(data[1]), PosY = float.Parse(data[2]) });
                    }
                }
            }
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
