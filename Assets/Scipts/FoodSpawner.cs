using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class FoodSpawner : MonoBehaviour
{

    [SerializeField]
    Itemv2 item;
    [SerializeField]
    Itemv2 item1;
    [SerializeField]
    Itemv2 item2;

    private bool foodspawner = false;
    public UnityEvent hidefs;

    public UnityEvent showtext;
    public UnityEvent hidetext;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
                    int num1 = rnd.Next(1, 10);

                    for (int i = 0; i < num1; i++)
                    {
                        In.Instance.Add(item1);
                    }
                    int num2 = rnd.Next(1, 10);
                    if(num2 ==2)
                        In.Instance.Add(item2);
                    foodspawner = false;
                    hidefs.Invoke();
                    hidetext.Invoke();
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
            showtext.Invoke();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("saiu");
            foodspawner = false;
            hidetext.Invoke();
        }


    }
}