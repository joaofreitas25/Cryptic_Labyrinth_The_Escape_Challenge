using StarterAssets;
using UnityEngine;

public abstract partial class BaseState : IState
{
    protected readonly FirstPersonController player;
    protected readonly Animator animator;

    protected static readonly int LocomotionHash = Animator.StringToHash("Walk");
    protected static readonly int IdleHash = Animator.StringToHash("Idle");
    protected static readonly int AttackHash = Animator.StringToHash("Attack");
    protected static readonly int DieHash = Animator.StringToHash("Die");
    protected static readonly int JumpHash = Animator.StringToHash("Jump");
    protected const float crossFadeDuration = 0.1f;
    protected BaseState(FirstPersonController player,Animator animator) 
    {
        this.player = player;
        this.animator = animator;
    }
    public virtual void OnEnter()
    {
        //noop
    }
    public virtual void Update()
    {
        //noop
    }
    public virtual void FixedUpdate()
    {
        //noop
    }
    public virtual void OnExit()
    {
        //noop
    }
}
