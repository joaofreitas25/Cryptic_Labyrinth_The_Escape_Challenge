using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DT1 : MonoBehaviour
{

    void Start()
    {
        gameObject.GetComponent<Animation>().wrapMode = WrapMode.Loop;
        gameObject.GetComponent<Animation>().Play("arm");
        gameObject.GetComponent<Animation>().Play("trunk");
    }
}

