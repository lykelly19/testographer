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
    int levelMultiplier;

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
    public int LevelMultiplier 
    { 
        get { return levelMultiplier; }
        set { levelMultiplier = value; }
    }

    // Constructor
    public Score()
    {
        currentScore = 0;
        // Start at -1 for variables not used until calculateFinalScore.
        originalScore = -1;
        timeBonus = -1;
        levelMultiplier = -1;
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
    public void calculateFinalScore(int timeElapsed, int level)
    {
        // Set original score before bonus.
        originalScore = currentScore;

        // Calculate level multiplier.
        if(level == 0)
        {
            levelMultiplier = 1;
        } else if (level == 1)
        {
            levelMultiplier = 2;
        } else
        {
            Console.WriteLine("Error, invalid level in calculateFinalScore. Exiting . . .");
            System.Environment.Exit(-1);
        }

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
        currentScore *= levelMultiplier;
        currentScore += timeBonus;

        DataManager dm = FindObjectOfType<DataManager>();
        dm.finalScoreText = getEndScoreDisplay();
    }

    public string getEndScoreDisplay()
    {
        return "Your Score: " + originalScore + " x " + levelMultiplier + " + " + timeBonus + " = " + currentScore;
    }
}
