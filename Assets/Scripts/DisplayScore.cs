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
     Map tempMap = GameManager.currentMap;
     Score tempScore = tempMap.score;
     int originalScore = tempScore.originalScore;
     int levelMultiplier = tempScore.levelMultiplier;
     int timeBonus = tempScore.timeBonus;
     int finalScore = tempScore.currentScore;
     scoreText.text = "Your Score: " + originalScore + " x " + levelMultiplier + " + " + timeBonus + " = " + finalScore;   
    }
}
