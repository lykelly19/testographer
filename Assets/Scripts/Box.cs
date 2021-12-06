using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    // DECLARATIONS
    // id is the Box.name
	private float x;
	private float y;
    private int level;
    private string label;
    public Text boxText;
    public string abbreviation;

    public string Label
    {
        get
        {
            return label;
        }
        set
        {
            label = value;
            boxText.text = label;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

    // GETTERS AND SETTERS
    public float X
    {
        get
        {
            return x;
        }
        set
        {
            x = value;
        }
    }

    public float Y
    {
        get
        {
            return y;
        }
        set
        {
            y = value;
        }
    }

    // METHODS

    // give the box highlighted styling
    public void highlight()
    {
        if(GetComponent<Renderer>())
            GetComponent<Renderer>().material.color = new Color(0.062f, 0.22f, 0.0f, 1);
    }

    // unhighlight the box
    public void unHighlight()
    {
        if(GetComponent<Renderer>())
            GetComponent<Renderer>().material.color = Color.white;
    }

    // on mouse over, highlight the box
    void OnMouseOver()
    {
        highlight();
    }

    void OnMouseExit()
    {
        unHighlight();
    }


    // Start is called before the first frame update
    private void Start()
    {
        BoxCollider2D boxCollider = gameObject.AddComponent<BoxCollider2D>();

        label = "";
        if (level == 0)
        {
            // If Easy mode, add first letter.
            // If Hard mode, label stays the same.
            label += gameObject.name[0];
        } else if (level != 1)
        {
            
            Console.WriteLine("Error, invalid level in Box. Exiting . . .");
            System.Environment.Exit(-1);
        }
    }
}
