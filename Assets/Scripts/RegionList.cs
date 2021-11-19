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

    public List<string> generateSidebarList(int size)
    {
        List<string> sidebarList = new List<string>();

        while (sidebarList.Count < size)
        {
            string newItem = getRandomUnmatchedId();

            // make sure a string was returned and that it's not a duplicate id
            if(newItem != null && !sidebarList.Exists(s => s == newItem))
            {
                sidebarList.Add(newItem);
            }
        }

        return sidebarList;
    }

    // Replaces marks a Region and matched and replaces it in the sidebarList. if there's no unmatched
    // regions left, it is simply removed from sidebarList.
    public List<string> replaceRegion(List<string> sidebarList, int index)
    {
        int regionIndex = findIdMatch(sidebarList[index]);

        if(regionIndex >= 0 && regionIndex < regions.Count)
        {
            setMatched(regionIndex, true);

            string newItem = getRandomUnmatchedId();
            if(newItem != null)
            {
                sidebarList[index] = newItem;
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
    private string getRandomUnmatchedId()
    {
        var rand = new System.Random();

        List<string> unmatched = getUnmatched();

        if (unmatched == null)
        {
            return null;
        }

        int index = rand.Next(unmatched.Count);

        return unmatched[index];
    }

    private List<string> getUnmatched()
    {
        List<string> unmatched = new List<string>();

        for(int i = 0; i < regions.Count; i++)
        {
            if (!regions[i].IsMatched)
            {
                unmatched.Add(regions[i].Id);
            }
        }

        if (unmatched.Count < 1)
        {
            return null;
        }

        return unmatched;
    }
}
