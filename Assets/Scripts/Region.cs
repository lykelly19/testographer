using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    string id;
    bool isMatched;
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
}
