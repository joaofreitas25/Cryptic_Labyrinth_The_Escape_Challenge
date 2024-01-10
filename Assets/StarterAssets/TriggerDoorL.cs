using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDoorL : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator mydoor = null;
    public UnityEvent psound;
    public UnityEvent hsound;


    private void Update()
    {
        door();
    }

    private void door()
    {
        if (timer1.Instance.currentTime.Hour == 9 && timer1.Instance.currentTime.Minute == 0)
        {
            mydoor.Play("DoorOpenL", 0, 0.0f);
            StartCoroutine("sound");
            print("yoyoyoyo");
        }

        if (timer1.Instance.currentTime.Hour == 20 && timer1.Instance.currentTime.Minute == 0)
        {
            mydoor.Play("DoorCloseL", 0, 0.0f);
            StartCoroutine("sound");
        }
    }

    IEnumerator sound()
    {
        psound.Invoke();
        yield return new WaitForSeconds(1);
        hsound.Invoke();
    }



}
