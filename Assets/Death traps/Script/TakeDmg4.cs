using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeDmg4: MonoBehaviour
{
    public UnityEvent takedmg4;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer1.Instance.Takedmg4();
        }
    }
}