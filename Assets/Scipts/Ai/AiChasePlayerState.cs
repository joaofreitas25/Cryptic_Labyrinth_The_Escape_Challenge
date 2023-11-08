using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AiChasePlayerState : AiState

{
    float timer = 0.0f;

    public AiStateId GetId()
    {
        return AiStateId.ChasePlayer;
    }
    public void Enter(AiAgent agent)
    {
      
    }

    public void Update(AiAgent agent)
    {
        if (!agent.enabled)
        {
            return;
        }
        timer -= Time.deltaTime;
        if (!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.destination = agent.playerTransform.position;
        }
        if (timer < 0.0f)
        {
            Vector3 direction = (agent.playerTransform.position - agent.navMeshAgent.destination);
            direction.y = 0;
            if (direction.sqrMagnitude > agent.config.maxDistance * agent.config.maxDistance)
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    agent.navMeshAgent.destination = agent.playerTransform.position;
                }
            }

            Vector3 agentDirection = agent.transform.forward;
            Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
            playerDirection.Normalize();
            float dotProduct = Vector3.Dot(playerDirection, agentDirection);
            if (dotProduct > 0.0f)
            {
                agent.stateMachine.ChangeState(AiStateId.Attack);
            }
        }
        agent.animator.SetFloat("speed", 5f);
        timer = agent.config.maxTime;

    }
    public void Exit(AiAgent agent)
    {

    }
}
