using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    public AiStateMachine stateMachine;
    public AiStateId initialState;
    public NavMeshAgent navMeshAgent;
    public AiAgentConfig config;
    public SkinnedMeshRenderer mesh;
    public Transform playerTransform;
    public Animator animator;
    public Transform[] patrolPoints;
    public LayerMask playerLayer;
    public Player Player;
    


    //private int health; // Assuming the AI has 100 health initially

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        stateMachine = new AiStateMachine(this);
        stateMachine.RegisterState(new AiChasePlayerState());
        stateMachine.RegisterState(new AiDeathState());
        stateMachine.RegisterState(new AiIdleState());
        stateMachine.RegisterState(new AiAttack());
        stateMachine.RegisterState(new AiPatrolState());
        stateMachine.ChangeState(initialState);
        //health = 100;
    }

    //public void TakeDamage(int damageAmount)
    //{
       
    //    // Reduce health
        
    //    health -= damageAmount;


    //    // Check if the AI is defeated
    //    if (health <= 0)
    //    {
    //        Die(); // Implement the logic for AI death
    //    }
    //    else
    //    {
    //        // Implement any other visual/audio feedback for taking damage
    //    }
    //}

    //private void Die()
    //{
    //    // Implement logic for AI death, such as playing death animation, disabling AI, etc.
    //    // You might want to trigger a state change to a death state in your state machine.
    //    stateMachine.ChangeState(AiStateId.Death);
    //}

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
}
