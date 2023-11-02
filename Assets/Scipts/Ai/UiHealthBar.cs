using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHealthBar : MonoBehaviour
{
    public Transform target;
    void LateUpdate()
    {
        transform.position = Camera.main.WorldToScreenPoint(target.position);
    }
}
