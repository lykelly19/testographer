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
     int USHighScore = 0;
     scoreText.text = "United States\nHigh Score: " + USHighScore;
    }
}

