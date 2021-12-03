using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    string id;
    bool isMatched = false;
    Vector2 regionCoordinates;
    System.Action<string, Vector2> isDroppedCallback;
    public bool dragging = false;
    private Vector2 originalPosition;

    public void Start()
    {
        originalPosition = transform.position;
    }

    public void OnMouseDown()
    {
        dragging = true;
    }

    public void OnMouseUp()
    {
        dragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 objPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = objPos;
        }
        else
        {
            transform.position = originalPosition;
        }
    }

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

    public System.Action<string, Vector2> IsDroppedCallback
    {
        set
        {
            isDroppedCallback = value;
        }
    }
}
