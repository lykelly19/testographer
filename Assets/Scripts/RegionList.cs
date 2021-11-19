using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript
{
    List<Region> regions;

    // Returns index of Region with matching ID
    public int findIdMatch(string id)
    {
        for(int i = 0; i < regions.Count; i++)
        {
            if (checkIdMatch(regions[i], id))
            {
                return i;
            }
        }

        return -1;
    }

    // Checks if Region has the id
    private bool checkIdMatch(Region r, string id)
    {
        if (r.Id == id)
        {
            return true;
        }
        return false;
    }
    
    // sets the isMatched flag to indicate that the Region at index i has been matched
    private void setMatched(int index, bool isMatched)
    {
        if(index >= 0 && index < regions.Count)
        {
            regions[index].IsMatched = isMatched;
        }
    }

    /*
     * generateSidebarList() => RegionList 
     * Randomly generates a list of ten Regions and returns it
     */

    // Replaces marks a Region and matched and replaces it in the sidebarList. if there's no unmatched
    // regions left, it is simply removed from sidebarList.
    public List<string> replaceRegion(List<string> sidebarList, int index)
    {
        int regionIndex = findIdMatch(sidebarList[index]);

        if(regionIndex >= 0 && regionIndex < regions.Count)
        {
            setMatched(regionIndex, true);

            Region newItem = getRandomUnmatched();
            if(newItem != null)
            {
                sidebarList[index] = newItem.Id;
            } 
            else
            {
                sidebarList.RemoveAt(index);
            }
        }

        return sidebarList;
    }
    /*
     * getRandomUnmatched() => Region
     * Picks a random item in unmatched and returns it
     * */
    private Region getRandomUnmatched()
    {
        System.Console.WriteLine("FIXME: RegionList.getRandomUnmatched is incomplete and will always return null\n");
        return null;
    }
}
