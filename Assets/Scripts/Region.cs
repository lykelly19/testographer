using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    string regionName;
    Vector2 regionCoordinates;
    
    public string RegionName
    {
        get
        {
            return regionName;
        }
        set
        {
            regionName = value;
        }
    }
}
