using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AiDeathState : AiState
{
    public Vector3 direction;
    public AiStateId GetId()
    {
        return AiStateId.Death;
    }
    public void Enter(AiAgent agent)
    {
        agent.ragdoll.ActivateRagdoll();
        direction.y = 1;
        agent.ragdoll.ApplyForce(direction * agent.config.dieForce);
        //healthBar.gameobject.SetActive(false);
        agent.mesh.updateWhenOffscreen = true;
    }
    public void Update(AiAgent agent)
    {
    }
    public void Exit(AiAgent agent)
    {
      
    }

  

    
}
