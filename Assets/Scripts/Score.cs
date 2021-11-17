using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    // Variables with get and set functions.
    public int currentScore 
    { 
        get { return currentScore; }
        set { currentScore = value; }
    }
    public int originalScore 
    { 
        get { return originalScore; }
        set { originalScore = value; }
    }
    public int timeBonus 
    {
        get { return timeBonus; }
        set { timeBonus = value; }
    }
    public int levelMultiplier 
    { 
        get { return levelMultiplier; }
        set { levelMultiplier = value; }
    }

    // Constructor
    public Score()
    {
        currentScore = 0;
        originalScore = 0;
        timeBonus = 0;
        levelMultiplier = 0;
    }

    // Changes score based on the correctness of the most recent choice.
    // +50 points if correct, -25 if incorrect.
    public void changeScore(bool isRight)
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
    public void calculateFinalScore(int timeElapsed, int level)
    {
        // will add very soon
    }
}
