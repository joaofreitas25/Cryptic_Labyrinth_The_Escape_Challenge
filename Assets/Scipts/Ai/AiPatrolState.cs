using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AiPatrolState : AiState
{
    private Transform[] patrolPoints;
    private int currentPatrolIndex = 0;
    private float timeAtPatrolPoint = 0.0f;
    private float patrolPointDelay = 2.0f;
    private float detectionAngle = 45.0f; // Adjust this angle as needed
    private float detectionDistance = 10.0f; // Adjust this distance as needed

    public AiStateId GetId()
    {
        return AiStateId.Patrol;
    }

    public void Enter(AiAgent agent)
    {
        patrolPoints = agent.patrolPoints;
        SetNextPatrolDestination(agent);
    }

    public void Update(AiAgent agent)
    {
        // Check for player detection
        Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
        playerDirection.y = 0; // Ignore vertical component
        float distanceToPlayer = playerDirection.magnitude;
        playerDirection.Normalize();

        Vector3 agentDirection = agent.transform.forward;
        float angleToPlayer = Vector3.Angle(agentDirection, playerDirection);

        if (angleToPlayer < detectionAngle && distanceToPlayer < detectionDistance)
        {
            // Ensure there are no obstacles between the agent and the player
            if (!IsObstacleBetween(agent.transform.position, agent.playerTransform.position, agent.playerLayer))
            {
                agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
                return;
            }
        }

        // Check if the agent has reached the current patrol point
        if (agent.navMeshAgent.remainingDistance < 0.1f && !agent.navMeshAgent.pathPending)
        {
            timeAtPatrolPoint += Time.deltaTime;

            if (timeAtPatrolPoint >= patrolPointDelay)
            {
                timeAtPatrolPoint = 0.0f;
                SetNextPatrolDestination(agent);
            }
        }

        // Update animator or any other logic as needed
        agent.animator.SetFloat("speed", 1f);
    }

    // Helper method to check for obstacles between two points
    private bool IsObstacleBetween(Vector3 start, Vector3 end, LayerMask layerMask)
    {
        RaycastHit hit;
        if (Physics.Raycast(start, end - start, out hit, Vector3.Distance(start, end), layerMask))
        {
            return true; // Obstacle detected
        }
        return false; // No obstacle
    }

    public void Exit(AiAgent agent)
    {
        // Cleanup or perform any necessary actions when exiting the patrol state
    }

    private IEnumerator SetNextPatrolDestinationCoroutine(AiAgent agent)
    {
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        Vector3 targetPosition = patrolPoints[currentPatrolIndex].position;

        // Sample a valid position on the NavMesh near the target position
        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetPosition, out hit, 2.0f, NavMesh.AllAreas))
        {
            agent.navMeshAgent.SetDestination(hit.position);

            // Wait for a short delay before setting the next destination
            yield return new WaitForSeconds(patrolPointDelay);

            // Start the coroutine for the next patrol destination
            agent.StartCoroutine(SetNextPatrolDestinationCoroutine(agent));
        }
    }

    private void SetNextPatrolDestination(AiAgent agent)
    {
        // Start the coroutine for the first patrol destination
        agent.StartCoroutine(SetNextPatrolDestinationCoroutine(agent));
    }
}
