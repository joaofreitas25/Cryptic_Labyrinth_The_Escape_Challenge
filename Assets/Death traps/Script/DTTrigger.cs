using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider obj)
    {
        GameObject thespikes = GameObject.FindWithTag("spikes");
        thespikes.GetComponent<Animation>().Play("spikes");
    }
}
