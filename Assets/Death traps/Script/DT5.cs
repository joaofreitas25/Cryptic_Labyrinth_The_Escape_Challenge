using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DT5 : MonoBehaviour
{
    
    void Start()
    {
        gameObject.GetComponent<Animation>().wrapMode = WrapMode.Loop;
        gameObject.GetComponent<Animation>().Play("blade2");
    }


}
