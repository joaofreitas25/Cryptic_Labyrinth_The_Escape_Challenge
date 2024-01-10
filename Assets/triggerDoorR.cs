using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDoorR : MonoBehaviour
{
    [SerializeField] private Animator mydoor = null;


    private void Update()
    {
        door();
    }

    private void door()
    {
        if (timer1.Instance.currentTime.Hour == 9 && timer1.Instance.currentTime.Minute == 0)
        {
            mydoor.Play("DoorOpenR", 0, 0.0f);
            print("yoyoyoyo");
        }

        if (timer1.Instance.currentTime.Hour == 20 && timer1.Instance.currentTime.Minute == 0)
        {
            mydoor.Play("DoorCloseR", 0, 0.0f);
        }
    }
}
