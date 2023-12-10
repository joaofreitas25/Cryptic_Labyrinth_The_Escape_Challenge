using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AiChasePlayerState : AiState
{
    float timer = 0.0f;
    bool hasPlayerInSight = false;

    // Add a coroutine reference for delaying the transition to Attack state
    private Coroutine attackDelayCoroutine;

    public AiStateId GetId()
    {
        return AiStateId.ChasePlayer;
    }

    public void Enter(AiAgent agent)
    {
        // Start chasing the player immediately
        agent.navMeshAgent.destination = agent.playerTransform.position;

        // Reset flags and coroutine reference
        hasPlayerInSight = false;
        attackDelayCoroutine = null;
        agent.audioSource = agent.chaseSound;
        agent.audioSource.loop = true; // Configurar para repetir
        agent.audioSource.Play();
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

        Vector3 agentDirection = agent.transform.forward;
        Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
        playerDirection.Normalize();
        float dotProduct = Vector3.Dot(playerDirection, agentDirection);

        if (dotProduct > 0.0f)
        {
            // Player is in sight
            hasPlayerInSight = true;

            // Check if the coroutine is already running to avoid starting multiple coroutines
            if (attackDelayCoroutine == null)
            {
                // Start the coroutine for the attack delay
                attackDelayCoroutine = agent.StartCoroutine(AttackDelayCoroutine(agent));
            }
        }
        else
        {
            // Player is not in sight
            hasPlayerInSight = false;

            // Reset the coroutine reference when player is out of sight
            attackDelayCoroutine = null;
        }

        agent.animator.SetFloat("speed", 5f);
        timer = agent.config.maxTime;
    }

    public void Exit(AiAgent agent)
    {
        // Stop the attack delay coroutine when exiting the state
        if (attackDelayCoroutine != null)
        {
            agent.StopCoroutine(attackDelayCoroutine);
            attackDelayCoroutine = null;
            agent.audioSource.Stop();

        }
    }

    // Coroutine for introducing a delay before transitioning to Attack state
    private IEnumerator AttackDelayCoroutine(AiAgent agent)
    {
        // Adjust the delay duration as needed
        float delayDuration = 2.0f;

        // Wait for the delay duration or until the player is out of sight
        yield return new WaitUntil(() => timer <= 0.0f || !hasPlayerInSight);

        // Change to the Attack state after the delay
        agent.stateMachine.ChangeState(AiStateId.Attack);
    }
}
