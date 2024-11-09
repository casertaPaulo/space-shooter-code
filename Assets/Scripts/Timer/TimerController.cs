using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerController : MonoBehaviour
{

    public float timer = 0f;
    public TextMeshProUGUI timerText;

    void Start()
    {
     
    }
    void Update()
    {
        timer += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(timer);
       // timerText.text = "Timer: " + time.Minutes.ToString() + ":" + time.Seconds.ToString();
        timerText.text = "Timer: " + string.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
    }
}
