using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public Text text;
    public float minutes = 3f;
    public float seconds = 0f;
    public bool stopTime = false;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        text.text = RecordTime(1);
    }

    public string RecordTime(float timeSpeed)
    {
        string time;

        if (!stopTime)
        {
            seconds -= timeSpeed * Time.deltaTime;
        }

        if (seconds < 0)
        {
            seconds = 59;

            minutes -= 1;
        }

        if (minutes == 0)
        {
            minutes = 0;
        }

        if (minutes < 0)
        {
            time = "0:00";
        }
        else
        {
            if (seconds > 10)
                time = (int)minutes + ":" + (int)seconds;
            else
                time = (int)minutes + ":0" + (int)seconds;
        }

        return time;
    }
}
