using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    //[SerializeField]
    //private GameObject pickUpUI;

 

    [SerializeField]
    [Min(1)]
    private float hitRange = 3;

    [SerializeField]
    private Transform pickUpParent;

    [SerializeField] 
    private GameObject inHandItem;

    [SerializeField]
    private InputActionReference interactionInput, dropInput, useInput;

    private RaycastHit hit;

    private void Start()
    {
        interactionInput.action.performed += Interact;
        dropInput.action.performed += Drop;
        useInput.action.performed += Use;
    }

    private void Use(InputAction.CallbackContext obj)
    {

    }

    private void Drop(InputAction.CallbackContext obj)
    {
        if(inHandItem != null) 
        {
            inHandItem.transform.SetParent(null);
            inHandItem = null;
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
        }

    }

    private void Interact(InputAction.CallbackContext obj)
    {
        if(hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            Rigidbody rb=hit.collider.GetComponent<Rigidbody>();
            if(hit.collider.GetComponent<Item>() || hit.collider.GetComponent<Food>()) 
            {
                Debug.Log("It's a flashlight");
                inHandItem = hit.collider.gameObject;
                inHandItem.transform.position = Vector3.zero;
                inHandItem.transform.rotation = Quaternion.identity;
                inHandItem.transform.SetParent(pickUpParent.transform, false);
                if(rb != null)
                {
                    rb.isKinematic = true;
                }
                return;
            }

        }
    }

    private void Update()
    {
        

        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.red); 
        if(hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            //pickUpUI.SetActive(false);
        }
        if (inHandItem != null)
        {
            return;
        }
        if (Physics.Raycast(playerCameraTransform.position,playerCameraTransform.forward,out hit, hitRange, pickableLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            //pickUpUI.SetActive(true);
        }
        
       
    }
    public void a()
    {
        Debug.Log("a");
    }
}