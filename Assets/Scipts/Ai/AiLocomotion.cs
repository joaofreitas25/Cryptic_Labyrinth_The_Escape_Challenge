using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AiLocomotion : MonoBehaviour
{
    public Transform playerTransform;
    NavMeshAgent agent;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {  
        agent= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        agent.destination = playerTransform.position;
        animator.SetFloat("speed",agent.velocity.magnitude);
    }
}
