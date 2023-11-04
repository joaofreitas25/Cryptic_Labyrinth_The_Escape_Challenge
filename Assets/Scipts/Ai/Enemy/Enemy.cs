using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : Entity 
{
    [SerializeField, Self] NavMeshAgent agent;
    [SerializeField, Child] Animator animator;
}
