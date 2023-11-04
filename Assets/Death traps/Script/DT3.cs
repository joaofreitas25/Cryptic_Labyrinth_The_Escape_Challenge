using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DT3 : MonoBehaviour
{

    void Start()
    {
        gameObject.GetComponent<Animation>().wrapMode = WrapMode.Loop;
        gameObject.GetComponent<Animation>().Play("trunk_col2");
        gameObject.GetComponent<Animation>().Play("trunk2");

    }

  
}
