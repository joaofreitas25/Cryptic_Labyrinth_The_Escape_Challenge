using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeDmg : MonoBehaviour
{
    public UnityEvent takedmg;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { 
            print("trap");
            takedmg.Invoke();
        }
    }
}
