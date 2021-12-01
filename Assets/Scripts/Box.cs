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
        System.Console.WriteLine("FIXME: Box.highlight() is a stub and does nothing\n");
    }

    // unhighlight the box
    public void unHighlight()
    {
        System.Console.WriteLine("FIXME: Box.unHighlight() is a stub and does nothing\n");
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
       
    }
    
}
