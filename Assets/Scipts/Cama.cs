using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Cama : MonoBehaviour
{
    mycontrolls inputActions;
    public UnityEvent dormir;
    public bool cama = false;

    private void Awake()
    {
        inputActions = new mycontrolls();
    }
    private void Update()
    {
        if (cama == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                dormir.Invoke();
                print("dormir");
                cama = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            cama = true;
            print("cama");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            print("saiu");
            cama = false;
    }
}
