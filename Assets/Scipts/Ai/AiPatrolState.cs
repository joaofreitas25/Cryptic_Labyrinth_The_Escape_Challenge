using UnityEngine;

public class AiPatrolState : AiState
{
    private Transform[] patrolPoints; // Array of patrol points
    private int currentPatrolIndex = 0; // Index of the current patrol point
    private float timeAtPatrolPoint = 0.0f; // Timer to track time spent at the current patrol point
    private float patrolPointDelay = 2.0f; // Adjust as needed

    public AiStateId GetId()
    {
        return AiStateId.Patrol;
    }

    public void Enter(AiAgent agent)
    {
        // Initialize patrol points (you can set these in the Inspector)
        patrolPoints = agent.patrolPoints;

        // Set the initial destination to the first patrol point
        SetNextPatrolDestination(agent);
    }

    public void Update(AiAgent agent)
    {
        // Check for player detection
        Vector3 agentDirection = agent.transform.forward;
        Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
        playerDirection.Normalize();
        float dotProduct = Vector3.Dot(playerDirection, agentDirection);
        if (dotProduct > 0.0f)
        {
            agent.stateMachine.ChangeState(AiStateId.Attack);
            return;
        }

        // Check if the agent has reached the current patrol point
        if (agent.navMeshAgent.remainingDistance < 0.1f && !agent.navMeshAgent.pathPending)
        {
            // Increment the timer for the current patrol point
            timeAtPatrolPoint += Time.deltaTime;

            // Check if the time at the patrol point exceeds the delay
            if (timeAtPatrolPoint >= patrolPointDelay)
            {
                // Reset the timer and set the next patrol destination
                timeAtPatrolPoint = 0.0f;
                SetNextPatrolDestination(agent);
            }
        }

        // Update animator or any other logic as needed
        agent.animator.SetFloat("speed", 1f);
    }

    public void Exit(AiAgent agent)
    {
        // Cleanup or perform any necessary actions when exiting the patrol state
    }

    private void SetNextPatrolDestination(AiAgent agent)
    {
        // Set the next patrol point as the destination
        agent.navMeshAgent.destination = patrolPoints[currentPatrolIndex].position;

        // Increment the patrol index or reset to 0 if at the end
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }
}