using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionList
{
    
    // DECLARATIONS
    List<Region> regions;
    System.Action<string, Vector2> isDroppedCallback;


    public RegionList()
    {
        regions = new List<Region>();
        // populateList();
    }

    public System.Action<string, Vector2> IsDroppedCallback {
        get
        {
            return isDroppedCallback;
        }
        set {
            isDroppedCallback = value;
            foreach(Region r in regions) {
                r.IsDroppedCallback = isDroppedCallback;
            }
        }
    }

    // METHODS
    // public RegionList(System.Action<string, Vector2> isDropped)
    // {
    //     regions = new List<Region>();
    //     populateList();
    //     isDroppedCallback = isDropped;
    // }

    // Reads data from file at filePath and populates RegionList with it
    // private void populateList()
    // {
    //     // temporary data 
    //      string[] data = new string[] { "Maine", "Connecticut", "Pennsylvania", "New Jersey",
    //     "Delaware","New Hampshire","Vermont","Massachusetts","New York","Rhode Island"};

    //     for(int i=0; i<10; i++) {
    //         regions.Add(new Region() { Id = data[i], IsMatched = false, IsDroppedCallback = isDroppedCallback });
    //         Debug.Log(regions[i].Id);
    //     }
    // }


    // // Returns index of Region with matching ID
    // public int findIdMatch(string id)
    // {
    //     for(int i = 0; i < regions.Count; i++)
    //     {
    //         if (checkIdMatch(regions[i], id))
    //         {
    //             return i;
    //         }
    //     }

    //     return -1;
    // }

    // // Checks if Region has the id
    // private bool checkIdMatch(Region r, string id)
    // {
    //     if (r.Id == id)
    //     {
    //         return true;
    //     }
    //     return false;
    // }
    
    // // sets the isMatched flag to indicate that the Region at index i has been matched
    // private void setMatched(int index, bool isMatched)
    // {
    //     if(index >= 0 && index < regions.Count)
    //     {
    //         regions[index].IsMatched = isMatched;
    //     }
    // }

    // /*
    //  * generateSidebarList() => RegionList 
    //  * Randomly generates a list of ten Regions and returns it
    //  */

    // public List<Region> generateSidebarList(int size)
    // {
    //     List<Region> sidebarList = new List<Region>();

    //     while (sidebarList.Count < size)
    //     {
    //         Region newR = getRandomUnmatched();

    //         // make sure a string was returned and that it's not a duplicate id
    //         if(newR != null && !sidebarList.Exists(s => s.Id == newR.Id))
    //         {
    //             sidebarList.Add(newR);
    //         }
    //     }

    //     return sidebarList;
    // }

    // // Replaces marks a Region and matched and replaces it in the sidebarList. if there's no unmatched
    // // regions left, it is simply removed from sidebarList.
    // public List<Region> replaceRegion(List<Region> sidebarList, int index)
    // {
    //     int regionIndex = findIdMatch(sidebarList[index].Id);

    //     if(regionIndex >= 0 && regionIndex < regions.Count)
    //     {
    //         setMatched(regionIndex, true);

    //         Region newR = getRandomUnmatched();
    //         if(newR != null && findIdMatch(sidebarList, newR.Id) == -1)
    //         {
    //             sidebarList[index] = newR;
    //         } 
    //         else if (newR == null)
    //         {
    //             sidebarList.RemoveAt(index);
    //         }
    //     }

    //     return sidebarList;
    // }
    // /*
    //  * getRandomUnmatched() => Region
    //  * Picks a random item in unmatched and returns it
    //  * */
    // private Region getRandomUnmatched()
    // {
    //     var rand = new System.Random();

    //     List<Region> unmatched = getUnmatchedList();

    //     if (unmatched == null)
    //     {
    //         return null;
    //     }

    //     int index = rand.Next(unmatched.Count);

    //     return unmatched[index];
    // }

    // public bool checkAllMatched()
    // {
    //     if(getUnmatchedList() == null)
    //     {
    //         return true;
    //     }
    //     return false;
    // }
    // private List<Region> getUnmatchedList()
    // {
    //     List<Region> unmatched = new List<Region>();

    //     for(int i = 0; i < regions.Count; i++)
    //     {
    //         if (!regions[i].IsMatched)
    //         {
    //             unmatched.Add(regions[i]);
    //         }
    //     }

    //     if (unmatched.Count < 1)
    //     {
    //         return null;
    //     }

    //     return unmatched;
    // }

    // // Returns index of Region with matching ID
    // public int findIdMatch(List<Region> sidebarList, string id)
    // {
    //     for (int i = 0; i < regions.Count; i++)
    //     {
    //         if (checkIdMatch(regions[i], id))
    //         {
    //             return i;
    //         }
    //     }

    //     return -1;
    // }

    // // Resets RegionList back to it's initial state.
    // public void reset()
    // {
    //     // Sets every regions IsMatched to false.
    //     for(int i = 0; i < regions.Count; i++)
    //     {
    //         regions[i].IsMatched = false;
    //     }
    // }

    
}
