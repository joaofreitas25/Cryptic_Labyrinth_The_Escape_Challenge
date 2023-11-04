using StarterAssets;
using UnityEngine;

public abstract partial class BaseState
{
    public class LocomotionState : BaseState
    {
        public LocomotionState(FirstPersonController player, Animator animator) : base(player, animator) { }


        public override void OnEnter()
        {
            animator.CrossFade(LocomotionHash, crossFadeDuration);
        }
        public override void FixedUpdate()
        {
            player.Move();
        }
    }
}
