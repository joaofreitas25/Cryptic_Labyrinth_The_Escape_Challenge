using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeDmg3 : MonoBehaviour
{
    public UnityEvent takedmg3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer1.Instance.Takedmg3();

        }
    }
}
