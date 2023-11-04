using JetBrains.Annotations;
using StarterAssets;
using UnityEngine;

public class JumpState : BaseState
{
    public JumpState(FirstPersonController player, Animator animator) : base(player, animator) {}

    public override void OnEnter()
    {
        animator.CrossFade(JumpHash, crossFadeDuration);
    }
    public override void FixedUpdate() 
    {
        //call Player jump logic and move logic
        player.JumpAndGravity();
    }
}