using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Variables with get and set functions.
    int currentScore;
    int originalScore;
    int timeBonus;

    public int CurrentScore 
    { 
        get { return currentScore; }
        set { currentScore = value; }
    }
    public int OriginalScore 
    { 
        get { return originalScore; }
        set { originalScore = value; }
    }
    public int TimeBonus 
    {
        get { return timeBonus; }
        set { timeBonus = value; }
    }

    // Constructor
    public Score()
    {
        currentScore = 0;
        // Start at -1 for variables not used until calculateFinalScore.
        originalScore = -1;
        timeBonus = -1;
    }

    // Changes score based on the correctness of the most recent choice.
    // +50 points if correct, -25 if incorrect.
    public void updateScore(bool isRight)
    {
        if (isRight)
        {
            currentScore += 50;
        } else
        {
            currentScore -= 25;
        }
    }

    // Derives the final score based on the amount of time
    // elapsed and the difficulty of the level.
    // timeElapsed is in seconds.
    // level = 0 for easy, level = 1 for hard.
    public void calculateFinalScore(int timeElapsed)
    {
        // Set original score before bonus.
        originalScore = currentScore;

        // Calculate time bonus.
        double logCalc;
        if(timeElapsed <= 1000)
        {
            logCalc = Math.Log(timeElapsed) * 1000;
        } else if (timeElapsed <= 0)
        {
            logCalc = 0;
        } else
        {
            logCalc = 3000;
        }
        timeBonus = (3000 - (int) logCalc) / 10;

        // Calculate final score.
        // Multiplier is applied BEFORE time bonus is added.
 
        currentScore += Math.Abs(timeBonus);
    }

    public string getEndScoreDisplay()
    {
        return "Your Score: " + originalScore + " + " + timeBonus + " = " + currentScore;
    }
}
