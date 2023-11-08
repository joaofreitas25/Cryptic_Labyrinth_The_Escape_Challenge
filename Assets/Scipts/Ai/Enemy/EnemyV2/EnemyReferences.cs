using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyReferences : MonoBehaviour
{
    public NavMeshAgent navMeshagent;
    public Animator animator;
    public float pathUpdateDelay = 0.2f;

    private void Awake()
    {
        navMeshagent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();    
    }
}
