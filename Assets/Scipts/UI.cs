using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{

    public TMP_Text displayTime;
    public TMP_Text displayHp;
    public TMP_Text displayHunger;
    private float currentTime = 0;
    private float displayText;
    private int minutos = 0;
    private int hp = 100;
    private int hunger = 100;


    void Update()
    {
        currentTime += Time.deltaTime;
        displayText = Mathf.Round(currentTime);
        displayTime.text = minutos.ToString() + " : " + displayText.ToString();
        if (currentTime > 60)
        {
            minutos = minutos + 1;
            currentTime = 0;
        }

        displayHp.text = "HP : " + hp.ToString();
        displayHunger.text = "Hunger : " + hunger.ToString();
    }
}
