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

    public List<Region> generateSidebarList(int size)
    {
        List<Region> sidebarList = new List<Region>();

        while (sidebarList.Count < size)
        {
            Region newR = getRandomUnmatched();

            // make sure a string was returned and that it's not a duplicate id
            if(newR != null && !sidebarList.Exists(s => s.Id == newR.Id))
            {
                sidebarList.Add(newR);
            }
        }

        return sidebarList;
    }

    // Replaces marks a Region and matched and replaces it in the sidebarList. if there's no unmatched
    // regions left, it is simply removed from sidebarList.
    public List<Region> replaceRegion(List<Region> sidebarList, int index)
    {
        int regionIndex = findIdMatch(sidebarList[index].Id);

        if(regionIndex >= 0 && regionIndex < regions.Count)
        {
            setMatched(regionIndex, true);

            Region newR = getRandomUnmatched();
            if(newR != null)
            {
                sidebarList[index] = newR;
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
        var rand = new System.Random();

        List<Region> unmatched = getUnmatchedList();

        if (unmatched == null)
        {
            return null;
        }

        int index = rand.Next(unmatched.Count);

        return unmatched[index];
    }

    private List<Region> getUnmatchedList()
    {
        List<Region> unmatched = new List<Region>();

        for(int i = 0; i < regions.Count; i++)
        {
            if (!regions[i].IsMatched)
            {
                unmatched.Add(regions[i]);
            }
        }

        if (unmatched.Count < 1)
        {
            return null;
        }

        return unmatched;
    }
}