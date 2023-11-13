using System.Collections;
using UnityEngine;

public class AiDeathState : AiState
{
    private Animator animator;
    private bool isDeathAnimationPlayed;

    public AiStateId GetId()
    {
        return AiStateId.Death;
    }

    public void Enter(AiAgent agent)
    {
       
    }

    public void Update(AiAgent agent)
    {
        // Check if the death animation has finished playing
        if (animator != null && !isDeathAnimationPlayed && !animator.GetCurrentAnimatorStateInfo(0).IsName("DeathAnimation"))
        {
            // The death animation has finished playing
            isDeathAnimationPlayed = true;

            // Deactivate the GameObject
            agent.gameObject.SetActive(false);
        }
    }

    public void Exit(AiAgent agent)
    {
        // Clean up or perform any necessary actions when exiting the death state
    }
}
