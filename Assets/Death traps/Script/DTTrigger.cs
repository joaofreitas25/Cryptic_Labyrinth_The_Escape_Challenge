using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    private void OnTriggerEnter(Collider obj)
    {
        GameObject thespikes = GameObject.FindWithTag("spikes");
        thespikes.GetComponent<Animation>().Play("spikes");
        AudioSource audioSource1 = audioSource;
        audioSource1.Play();

    }
}