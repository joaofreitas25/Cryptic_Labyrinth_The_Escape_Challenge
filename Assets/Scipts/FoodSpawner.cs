using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class FoodSpawner : MonoBehaviour
{

    [SerializeField]
    Itemv2 item;


    private bool foodspawner = false;
    public UnityEvent hidefs;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer1.Instance.currentTime.Hour > 10)
        {
            if (foodspawner)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {


                    int num = rnd.Next(1, 10);

                    for (int i = 0; i < num; i++)
                    {
                        In.Instance.Add(item);
                    }
                    foodspawner = false;
                    hidefs.Invoke();
                }
            }
        }

    }

    public void OnFS()
    {
        
    }

    System.Random rnd = new System.Random();


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foodspawner = true;
            print("a");
            OnFS();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("saiu");
            foodspawner = false;
        }


    }
}