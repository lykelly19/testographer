using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionList
{

    // DECLARATIONS
    List<string> unmatched;
    List<string> matched;


    public RegionList()
    {
        unmatched = new List<string>();
        matched = new List<string>();

        unmatched.Add("Maine");
        unmatched.Add("New Hampshire");
        unmatched.Add("Vermont");
        unmatched.Add("Massachusetts");
        unmatched.Add("New York");
        unmatched.Add("Rhode Island");
        unmatched.Add("Connecticut");
        unmatched.Add("Pennsylvania");
        unmatched.Add("New Jersey");
        unmatched.Add("Delaware");
        unmatched.Add("Maryland");
        unmatched.Add("West Virginia");
        unmatched.Add("Virginia");
        unmatched.Add("Ohio");
        unmatched.Add("Michigan");
        unmatched.Add("Indiana");
        unmatched.Add("Illinois");
        unmatched.Add("Wisconsin");
        unmatched.Add("Iowa");
        unmatched.Add("Minnesota");
        unmatched.Add("North Dakota");
        unmatched.Add("South Dakota");
        unmatched.Add("Montana");
        unmatched.Add("Wyoming");
        unmatched.Add("Idaho");
        unmatched.Add("Oregon");
        unmatched.Add("Washington");
        unmatched.Add("California");
        unmatched.Add("Nevada");
        unmatched.Add("Utah");
        unmatched.Add("Arizona");
        unmatched.Add("Colorado");
        unmatched.Add("New Mexico");
        unmatched.Add("Kansas");
        unmatched.Add("Oklahoma");
        unmatched.Add("Texas");
        unmatched.Add("Missouri");
        unmatched.Add("Arkansas");
        unmatched.Add("Louisiana");
        unmatched.Add("Mississippi");
        unmatched.Add("Alabama");
        unmatched.Add("Georgia");
        unmatched.Add("Florida");
        unmatched.Add("Tennessee");
        unmatched.Add("North Carolina");
        unmatched.Add("South Carolina");
        unmatched.Add("Kentucky");
        unmatched.Add("Alaska");
        unmatched.Add("Hawaii");
        unmatched.Add("Nebraska");
    }

    // METHODS

    // Checks if Region has the id
    private bool checkIdMatch(string regionID, string checkID)
    {
        if (regionID == checkID)
        {
            return true;
        }
       return false;
    }

    // moves region from unmatched to matched
    private void setMatched(string id)
    {
        matched.Add(id);
        unmatched.Remove(id);
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
            string id = getRandomUnmatched();

            // make sure a string was returned and that it's not a duplicate id
            if(id != null && !sidebarList.Exists(s => s == id))
            {
                sidebarList.Add(id);
            }
        }

        return sidebarList;
    }

   // gets a new unmatched ID to put in the sidebarList
    public string getReplacementId(Region[] sidebarList, string id)
    {
        string newId = null;

        setMatched(id);

        if(unmatched.Count < sidebarList.Length)
        {
            return null;
        }

        do
        {
            newId = getRandomUnmatched();
        } while (newId != null && System.Array.Exists(sidebarList, r => r.Id == newId));
        
        return newId;
    }
    /*
     * getRandomUnmatched() => string
     * Picks a random item in unmatched and returns it
     * */
    private string getRandomUnmatched()
    {
        if (!allMatched())
        {
            var rand = new System.Random();
            int index = rand.Next(unmatched.Count);

            return unmatched[index];
        }

        return null;
    }

    public bool allMatched()
    {
        if(unmatched.Count <= 0)
        {
            return true;
        }
        return false;
    }
   

    // Resets RegionList back to it's initial state.
    public void reset()
    {
        foreach(string s in matched)
        {
            unmatched.Add(s);
        }

        matched.Clear();
    }


}
