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
    public AudioSource idleSound;
    public AudioSource chaseSound;
    public AudioSource attackSound;
    public AudioSource patrolSound;
    public AudioSource audioSource;



    //private int health; // Assuming the AI has 100 health initially

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.minDistance = 5f;  // Ajuste conforme necessário
        audioSource.maxDistance = 20f; 
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
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1.0f; // 3D sound
        audioSource.volume = 0.0001f;
        audioSource.transform.position = transform.position;
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
        Debug.Log("AiAgent Position: " + transform.position);
        Debug.Log("AudioSource Position: " + audioSource.transform.position);
    }
}
