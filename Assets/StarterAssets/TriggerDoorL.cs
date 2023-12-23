using UnityEngine;

public class TriggerDoorL : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator mydoor = null;


    private void Update()
    {
        door();
    }

    private void door()
    {
        if (timer1.Instance.currentTime.Hour == 9 && timer1.Instance.currentTime.Minute == 0)
        {
            mydoor.Play("DoorOpenL", 0, 0.0f);
            print("yoyoyoyo");
        }

        if (timer1.Instance.currentTime.Hour == 10 && timer1.Instance.currentTime.Minute == 0)
        {
            mydoor.Play("DoorCloseL", 0, 0.0f);
        }
    }   
            
                
            
    
}
