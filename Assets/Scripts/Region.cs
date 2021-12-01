using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    string id;
    bool isMatched = false;
    Vector2 regionCoordinates;
    
    public string Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    public bool IsMatched
    {
        get
        {
            return isMatched;
        }
        set
        {
            isMatched = value;
        }
    }
}
