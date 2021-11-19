using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // DECLARATIONS
	private float posX;
	private float posY;

    // GETTERS AND SETTERS
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
