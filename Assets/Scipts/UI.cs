using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;

public class timer1 : MonoBehaviour
{
    public static timer1 Instance;

    private float timeMultiplier = 200;

    private float starthour = 8.50f;
    private float startcount = 0;

    public TextMeshProUGUI timeText;

    [SerializeField]
    private Light sunLight;
    private float sunriseHour = 7;
    private float sunsetHour = 20;

    public HealthBar healthBar;
    public HealthBar hungerBar;
    private TimeSpan sunriseTime;
    private TimeSpan sunsetTime;
    public TMP_Text displayTime;
    public TMP_Text displayHp;
    public TMP_Text displayHunger;
    private float displayText;
    public DateTime currentTime;
    private DateTime counttime;
    public float hp;
    public float hunger;
    public UnityEvent OpenP;
    public UnityEvent CloseP;
    public UnityEvent Showfs;
    private bool sleep = false;
    private bool inv = false;
    private bool takedmg = false;
    private bool takedmg2 = false;
    private bool takedmg3 = false;
    private bool takedmg4 = false;
    private bool takedmg5 = false;
    private bool takedmg6 = false;
    public bool img1 = false;
    public bool img2 = false;
    public bool img3 = false;
    public bool img4 = false;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(starthour);
        counttime = DateTime.Now.Date + TimeSpan.FromHours(startcount);

        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
        hp = 50;
        hunger = 70;
        healthBar.SetMaxHealth(100,hp);
        hungerBar.SetMaxHealth(100, hunger);
        

    }

    void Update()
    {
        counttime = counttime.AddSeconds(Time.deltaTime * timeMultiplier);
        UpdateTimeofDay();
        rotateSun();
        Portoes();
        Morte();
        showfs();
        cpuzzle1();
        cpuzzle2();
        cpuzzle3();
        cpuzzle4();
        Debug.Log(In.Instance.inventory);


        if (hunger < 0) hunger = 0;
        else if (hunger > 100) hunger = 100;
        else if (hp > 100) hp = 100;
        else
        {
            Hunger();
            
        }
        healthBar.SetHealth(hp);
        hungerBar.SetHealth(hunger);
        //Debug.Log(hunger);


    }

    public void Hunger()
    {
        if (counttime.Minute == 10)
        {
            hunger -= 1;
            counttime = DateTime.Now.Date + TimeSpan.FromMinutes(startcount);
            HealthRegen();
            print(hunger);
        }
    }
    public void Hunger2()
    {
        if (counttime.Minute == 2)
        {
            hunger -= 1;
            counttime = DateTime.Now.Date + TimeSpan.FromMinutes(startcount);
            
            print(hunger);
        }
    }


    private void Morte()
    {
        if (hp <=0)
        {
            SceneManager.LoadScene("Died");
            //print("morreu");
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
        if (currentTime.Hour == 9)
        {
            print("Abre");
            OpenP.Invoke();
        }
        if (currentTime.Hour == 15)
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
            if (currentTime.Hour > 20 || currentTime.Hour < 6)
            {
                currentTime = DateTime.Now.Date + TimeSpan.FromHours(starthour);
                sleep = false;
                print("yo");
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


    public void showfs()
    {
        if (currentTime.Hour == 10)
        {
            print("A");
            Showfs.Invoke();
        }
    }

    public void Takedmg()
    {
        takedmg = true;
        if (takedmg == true)
        {
            hp -= 25;
            takedmg = false;
        }
    }
    public void Takedmg2()
    {
        takedmg2 = true;
        if (takedmg2 == true)
        {
            hp -= 30;
            takedmg2 = false;
        }
    }
    public void Takedmg3()
    {
        takedmg3 = true;
        if (takedmg3 == true)
        {
            hp -= 20;
            takedmg3 = false;
        }
    }
    public void Takedmg4()
    {
        takedmg4 = true;
        if (takedmg4 == true)
        {
            hp -= 5;
            takedmg4 = false;
        }
    }
    public void Takedmg5()
    {
        takedmg5 = true;
        if (takedmg5 == true)
        {
            hp -= 45;
            takedmg5 = false;
        }
    }
    public void Takedmg6()
    {
        takedmg6 = true;
        if (takedmg6 == true)
        {
            hp -= 95;
            takedmg6 = false;
        }
    }

    public void comer()
    {
        hunger += 30;

        //Debug.Log(hunger);
    }
    public void beber()
    {
        hunger += 20;

        //Debug.Log(hunger);
    }
    public void medKit()
    {
        hp += 50;

        //Debug.Log(hunger);
    }

    private void HealthRegen()
    {
        if (hunger > 80)
        {


            hp += 1;
        }
    }

    public UnityEvent Puzzle1;
    public void puzzle1()
    {
        img1 = true;
        Puzzle1.Invoke();
        
        
    }
    public UnityEvent CPuzzle1;
    public void cpuzzle1()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && img1)
        {
            CPuzzle1.Invoke();
            
        }
        
    }

    public UnityEvent Puzzle2;
    public void puzzle2()
    {
        img2 = true;
        Puzzle2.Invoke();
    }
    public UnityEvent CPuzzle2;
    public void cpuzzle2()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && img2)
            CPuzzle2.Invoke();

    }
    public UnityEvent Puzzle3;
    public void puzzle3()
    {
        img3 = true;
        Puzzle3.Invoke();
    }
    public UnityEvent CPuzzle3;
    public void cpuzzle3()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && img3)
            CPuzzle3.Invoke();

    }
    public UnityEvent Puzzle4;
    public void puzzle4()
    {
        img4 = true;
        Puzzle4.Invoke();
    }
    public UnityEvent CPuzzle4;
    public void cpuzzle4()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && img4)
            CPuzzle4.Invoke();

    }







}