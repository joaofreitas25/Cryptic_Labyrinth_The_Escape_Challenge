using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHealth : MonoBehaviour
{
    public float maxHealth;
    [HideInInspector]
    public float currentHealth;
    AiAgent agent;
    SkinnedMeshRenderer skinnedMeshRenderer;
    UiHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
       
        agent = GetComponent<AiAgent>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        healthBar = GetComponentInChildren<UiHealthBar>();
        currentHealth = maxHealth;


        //var rigidBodies = GetComponentInChildren<Rigidbody>();
        //foreach (var rigidBody in rigidBodies)
        //{
         //   Hitbox hitbox = rigidBody.gameobject.AddComponent<Hitbox>();
           // hitbox.health = this;
        //}
    }

    public void TakeDamage(float amount,Vector3 direction)
    {
        currentHealth -= amount;
   
        if (currentHealth <= 0.0f)
        {
            Die(direction);
        }
    }
    private void Die(Vector3 direction)
    {
        
       AiDeathState deathState = agent.stateMachine.GetState(AiStateId.Death) as AiDeathState;
       deathState.direction = direction;
       agent.stateMachine.ChangeState(AiStateId.Death);

        
    }
}
