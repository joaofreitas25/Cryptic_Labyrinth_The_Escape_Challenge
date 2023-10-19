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
    private bool sleep;
    public UnityEvent OpenInv;
    public UnityEvent CloseInv;
    private bool inv;


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
        Invmanager();
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
            print("Abre");
            OpenP.Invoke();            
        }
        if (minutos == 2)
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
            if(minutos>20 || minutos<6)
            {
                minutos = 8;
                currentTime = 0;
                sleep = false;
            }
        }
    }
    public void Invmanager()
    {
        inv = false;
        if(inv == false)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                OpenInv.Invoke();
                inv = true;
            }
        }
        if (inv == true)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                CloseInv.Invoke();
                inv = false;
            }
        }
    }


}
