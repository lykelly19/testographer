using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // DECLARATIONS
    public string id;
	private float posX;
	private float posY;

    // GETTERS AND SETTERS
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
    public float PosX
    {
        get
        {
            return posX;
        }
        set
        {
            posX = value;
        }
    }

    public float PosY
    {
        get
        {
            return posY;
        }
        set
        {
            posY = value;
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
