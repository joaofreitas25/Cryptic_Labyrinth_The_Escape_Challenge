using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class timer : MonoBehaviour
{
    private float timeMultiplier = 1800;

    private float starthour = 8.50f;
    private float startcount = 0;

    public TextMeshProUGUI timeText;

    [SerializeField]
    private Light sunLight;
    private float sunriseHour = 7;
    private float sunsetHour = 20;


    private TimeSpan sunriseTime;
    private TimeSpan sunsetTime;
    public TMP_Text displayTime;
    public TMP_Text displayHp;
    public TMP_Text displayHunger;
    private float displayText;
    private DateTime currentTime;
    private DateTime counttime;
    private int hp = 100;
    private int hunger = 1;
    public UnityEvent OpenP;
    public UnityEvent CloseP;
    private bool sleep= false;
    public UnityEvent OpenInv;
    public UnityEvent CloseInv;
    private bool inv = false;


    private void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(starthour);
        counttime = DateTime.Now.Date + TimeSpan.FromHours(startcount);

        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
    }

    void Update()
    {
        UpdateTimeofDay();
        rotateSun();
        Portoes();
        Morte();
        Invmanager();
        counttime = counttime.AddSeconds(Time.deltaTime * timeMultiplier);
        if (hunger == 0) hunger = 0;
        else
        {
            if (counttime.Hour == 1)
            {
                hunger -= 1;
                counttime = DateTime.Now.Date + TimeSpan.FromHours(startcount);
            }
        }
        displayHp.text = "HP : " + hp.ToString();
        displayHunger.text = "Hunger : " + hunger.ToString();
        
    }


    private void Morte()
    {
        if (hp == 0)
        {
            hp = 0;
            
        }
        else
        {
            if (hunger == 0)
            {
                if (counttime.Hour == 1)
                {
                    hp -= 1;
                    counttime = DateTime.Now.Date + TimeSpan.FromHours(startcount);
                }
            }
        }
        
    }


    private void UpdateTimeofDay()
    {

        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);
        
        if (timeText != null)
        {
            timeText.text = currentTime.ToString("HH:mm");
        }

    }


    private void Portoes()
    {
        if(currentTime.Hour == 1)
        {
            print("Abre");
            OpenP.Invoke();            
        }
        if (currentTime.Hour == 2)
        {
            print("Fecha");
            CloseP.Invoke();
        }
    }

    public void dormir()
    {
        sleep = true;
        if (sleep == true)
        {
            if(currentTime.Hour > 20 || currentTime.Hour < 6)
            {
                currentTime = DateTime.Now.Date + TimeSpan.FromHours(starthour);
                sleep = false;
                print("yo");
            }
        }
    }
    public void Invmanager()
    {
        
        if(inv == false)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                OpenInv.Invoke();
                inv = true;
                Debug.Log(inv);
            }
        }
        if (inv == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CloseInv.Invoke();
                inv = false;
                Debug.Log(inv);
            }
        }

    }

    private void rotateSun()
    {
        float sunLightRotation;

        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan sunrisetoSunsetDuration = calculateTimeDiference(sunriseTime, sunsetTime);
            TimeSpan timesinceSunrise = calculateTimeDiference(sunriseTime, currentTime.TimeOfDay);

            double percentage = timesinceSunrise.TotalMinutes / sunrisetoSunsetDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);

        }
        else
        {
            TimeSpan sunsetToSunRiseDuration = calculateTimeDiference(sunsetTime, sunriseTime);
            TimeSpan timesinceSunSet = calculateTimeDiference(sunsetTime, currentTime.TimeOfDay);

            double percentage = timesinceSunSet.TotalMinutes / sunsetToSunRiseDuration.TotalMinutes;
            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);
        }

        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);
    }

    private TimeSpan calculateTimeDiference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan diference = toTime - fromTime;
        if (diference.TotalSeconds < 0)
        {
            diference += TimeSpan.FromHours(24);
        }
        return diference;
    }


}
