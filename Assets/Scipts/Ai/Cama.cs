using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;


public class Cama : MonoBehaviour
{
    mycontrolls inputActions;
    public UnityEvent dormir;
    public UnityEvent showtext;
    public UnityEvent hidetext;
    public bool cama = false;
    public TMP_Text text;

    private void Awake()
    {
        inputActions = new mycontrolls();
    }
    private void Update()
    {
        if (cama == true)
        {
            if (timer1.Instance.currentTime.Hour >= 20 || timer1.Instance.currentTime.Hour <= 6)
            {
                text.text = "Press E to sleep";
                if (Input.GetKeyDown(KeyCode.E))
                {

                    dormir.Invoke();
                    cama = false;
                }
            }
            else text.text = "You can only sleep between 20:00 and 6:00";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cama = true;
            print("cama");
            showtext.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cama = false;
            print("saiu ");
            hidetext.Invoke();
        }
    }
}
