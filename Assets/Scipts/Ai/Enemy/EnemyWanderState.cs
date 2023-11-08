﻿using UnityEngine;
using UnityEngine.AI;

public class EnemyWanderState : EnemyBaseState
{
    readonly NavMeshAgent agent;
    readonly Vector3 startPoint;
    readonly float wanderRadius;

    public EnemyWanderState(Enemy enemy, Animator animator,NavMeshAgent agent, float wanderRadius ) : base(enemy, animator)
    {
        this.agent = agent;
        //this.startPoint = enemy.transform.position;
        this.wanderRadius = wanderRadius;
    }

    public override void OnEnter()
    {
        Debug.Log("Wander");
        animator.CrossFade(ZwalkHash, crossFadeDuration);
    }

    public override void Update()
    {
        if (!HasReachedDestination())
        {
            //find a new destination
            
            Vector3 randomDirection = Random.insideUnitCircle * wanderRadius;
            randomDirection += startPoint;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit,wanderRadius,areaMask:1);
            var finalPosition = hit.position;
            agent.SetDestination(finalPosition);

        }
    }
    bool HasReachedDestination()
    {
        return !agent.pathPending
                && agent.remainingDistance <= agent.stoppingDistance
                && (!agent.hasPath || agent.velocity.sqrMagnitude == 0f);
    }
}
