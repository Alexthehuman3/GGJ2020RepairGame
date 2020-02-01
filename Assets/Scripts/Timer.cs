using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float secondsCounter;
    private int minuteCounter;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimerUI();
    }

    public void UpdateTimerUI()
    {
        secondsCounter += Time.deltaTime;
        timerText.text = minuteCounter + "m:" + (int)secondsCounter + "s";
        if(secondsCounter >= 60)
        {
            minuteCounter++;
            secondsCounter = 0;
        }
    }   
}
