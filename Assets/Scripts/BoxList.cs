using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxList
{
    Box[] boxes;
    int level;
    Dictionary<string,string> abbreviations;

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public BoxList(int difficulty)
    {
    	abbreviations = new Dictionary<string,string>()
    	{
    	{"Alabama","AL"},
    	{"Alaska","AK"},
    	{"Arizona","AZ"},
    	{"Arkansas","AR"},
    	{"California","CA"},
    	{"Colorado","CO"},
    	{"Connecticut","CT"},
    	{"Delaware","DE"},
    	{"Florida","FL"},
    	{"Georgia","GA"},
    	{"Hawaii","HI"},
    	{"Idaho","ID"},
    	{"Illinois","IL"},
    	{"Indiana","IN"},
    	{"Iowa","IA"},
    	{"Kansas","KS"},
    	{"Kentucky","KY"},
    	{"Louisiana","LA"},
    	{"Maine","ME"},
    	{"Maryland","MD"},
    	{"Massachusetts","MA"},
    	{"Michigan","MI"},
    	{"Minnesota","MN"},
    	{"Mississippi","MS"},
    	{"Missouri","MO"},
    	{"Montana","MT"},
    	{"Nebraska","NE"},
    	{"Nevada","NV"},
    	{"New Hampshire","NH"},
    	{"New Jersey","NJ"},
    	{"New Mexico","NM"},
    	{"New York","NY"},
    	{"North Carolina","NC"},
    	{"North Dakota","ND"},
    	{"Ohio","OH"},
    	{"Oklahoma","OK"},
    	{"Oregon","OR"},
    	{"Pennsylvania","PA"},
    	{"Rhode Island","RI"},
    	{"South Carolina","SC"},
    	{"South Dakota","SD"},
    	{"Tennessee","TN"},
    	{"Texas","TX"},
    	{"Utah","UT"},
    	{"Vermont","VT"},
    	{"Virginia","VA"},
    	{"Washington","WA"},
    	{"West Virginia","WV"},
    	{"Wisconsin","WI"},
    	{"Wyoming","WY"}
    	};
        
        level = difficulty;
        populateList();
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
            if(level == 0 && b.name.Length > 0)
            {
            	b.Label = b.name.Substring(0,1);
            }
            b.abbreviation = abbreviations[b.name];
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
                boxes[i].Label = boxes[i].abbreviation;
                boxes[i].setCorrectMatchColor();
                break;
            }
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
}
