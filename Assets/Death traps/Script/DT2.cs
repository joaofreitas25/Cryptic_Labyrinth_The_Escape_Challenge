using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DT2 : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Animation>().wrapMode = WrapMode.Loop;
        gameObject.GetComponent<Animation>().Play("stake1a");
        gameObject.GetComponent<Animation>().Play("stake1b");
    }

}
