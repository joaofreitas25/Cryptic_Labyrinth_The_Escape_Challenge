using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Cama : MonoBehaviour
{
    mycontrolls inputActions;
    public UnityEvent dormir;

    private void Awake()
    {
        inputActions = new mycontrolls();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            print("cama");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            print("saiu");
    }

    public void OnEnable()
    {
        inputActions.Enable();
    }

    public void OnDisable()
    {
        inputActions.Disable();
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(inputActions.Player.Interact.WasPressedThisFrame())
            {
                dormir.Invoke();    
                print("Sup");
            }
        }
    }
}
