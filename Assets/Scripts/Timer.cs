using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour

{

public Text timerText;
private float startTime;

    // resets the timer so counting can start again
    private void Reset()
    {
        startTime = Time.time;
    }
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // get the current number of elapsed seconds
    public float getElapsedSeconds()
    {
        return Time.time - startTime;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f1");
        
        timerText.text = "Time Elapsed " + minutes + ":" + seconds;
    }
}
