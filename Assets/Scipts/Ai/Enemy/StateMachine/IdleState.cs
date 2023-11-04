using JetBrains.Annotations;
using StarterAssets;
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(FirstPersonController player, Animator animator) : base(player, animator) { }

    public override void OnEnter()
    {
        animator.CrossFade(IdleHash, crossFadeDuration);
    }
    public override void FixedUpdate()
    {
        //call Player jump logic and move logic
        player.JumpAndGravity();
    }
}
