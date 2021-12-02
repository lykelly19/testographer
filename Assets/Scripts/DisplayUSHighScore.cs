using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUSHighScore : MonoBehaviour
{
   public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
     Map tempMap = GameManager.currentMap;
     int USHighScore = tempMap.HighScore;
     scoreText.text = "United States\nHigh Score: " + USHighScore;
    }
}

