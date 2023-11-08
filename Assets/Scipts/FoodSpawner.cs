using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FoodSpawner : MonoBehaviour
{

    [SerializeField]
    Itemv2 item;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    System.Random rnd = new System.Random();


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("entrou");

            int num = rnd.Next(0, 10);

            for (int i = 0; i < num; i++)
            {
                In.Instance.Add(item);
            }

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            print("saiu");

    }
}