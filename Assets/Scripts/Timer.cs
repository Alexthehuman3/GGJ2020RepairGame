using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float secondsCounter;
    private int minuteCounter;
    public GameController gc;


    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimerUI();
    }

    public void UpdateTimerUI()
    {
        if(gc.timeMoving)
        {
            secondsCounter += Time.deltaTime;
            timerText.text = "Time: " + minuteCounter + "m:" + (int)secondsCounter + "s";
            if (secondsCounter >= 60)
            {
                minuteCounter++;
                secondsCounter = 0;
            }
        }
    }   
}
