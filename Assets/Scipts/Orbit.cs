using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float theta=0.05f;
   
    void Update()
    {
        this.transform.RotateAround(Vector3.zero, Vector3.forward, theta);
    }
}
