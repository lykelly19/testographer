using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // DECLARATIONS
    // id is the Box.name
	private float x;
	private float y;

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
        GetComponent<Renderer>().material.color = Color.red;
    }

    // unhighlight the box
    public void unHighlight()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
    }
    
}
