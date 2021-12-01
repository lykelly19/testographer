using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour

{

public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
     int originalScore = 0;
     int levelMultiplier = 1;
     int timeBonus = 0;
     int finalScore = 0;
     scoreText.text = "Your Score: " + originalScore + " x " + levelMultiplier + " + " + timeBonus + " = " + finalScore;   
    }
}
