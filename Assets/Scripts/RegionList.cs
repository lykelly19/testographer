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
    public bool checkIdMatch(Region r, string id)
    {
        if (r.Id == id)
        {
            return true;
        }
        return false;
    }

    /*
     * moveToMatched (int index) => void
     * matched.push(unmatched.at(index));
     * unmatched.remove(index); // replace with equivalent C# functions
     */
    /*
     * generateSidebarList() => RegionList 
     * Randomly generates a list of ten Regions and returns it
     */
    /* 
     * replaceRegion(RegionList sidebarList, string id) => 
     * moveToMatched(findIdMatch(id)) to set it as matched
     * sidebarList.findIdMatch(id) = getRandomUnmatched();
     * Replaces its spot in sideBarList with an unmatched Region. If there’s no unmatched regions left,
     * it simply removes the Region without replacing it, so that size--.
     */
    /*
     * getRandomUnmatched() => Region
     * Picks a random item in unmatched and returns it
     * */
}
