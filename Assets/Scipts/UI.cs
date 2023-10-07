using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class timer : MonoBehaviour
{

    public TMP_Text displayTime;
    public TMP_Text displayHp;
    public TMP_Text displayHunger;
    private float currentTime = 0;
    private float displayText;
    private int minutos = 0;
    private int hp = 100;
    private int hunger = 1;
    private bool statusportoes = false;
    public UnityEvent OpenP;
    public UnityEvent CloseP;


    void Update()
    {
        currentTime += Time.deltaTime;
        displayText = Mathf.Round(currentTime);
        
        displayTime.text = minutos.ToString() + " : " + displayText.ToString();
        
        if (currentTime > 10)
        {
            minutos = minutos + 1;
            currentTime = 0;
            if (hunger == 0)
            { hunger = 0; }
            else hunger -= 1;
            
        }
        Portoes();
        Morte();
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
            if (currentTime /2 == 0)
            {
                hp -= 1;
            }
        }
        
    }

    private void Portoes()
    {
        if(minutos == 1)
        {
            statusportoes = true;
            print("true");
            
        }
        
    }
}
