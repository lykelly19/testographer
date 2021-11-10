using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Call this function to display a menu scene
    /*
    Parameters:
        buttons: list/array/whatever of objects. Each object has:
            getLabel(): the label that will display on this object's button
            id: value to be passed to onClick() function when button is clicked
            getSubLabel(): the sublabel that will display on this object's button
        onClick(): callback to fire when the button is clicked. The callback must accept the same
            data type as id of each object in buttons
        onGoBack(): event handler for clicking back button
        getTitle(): returns page title
        getSubtitle(): returns page subtitle
    */
    public void displayMenu() {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
