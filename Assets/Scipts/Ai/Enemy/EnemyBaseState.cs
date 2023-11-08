using UnityEngine;
    public abstract class EnemyBaseState : IState  
{
    protected readonly Enemy enemy;
    protected readonly Animator animator;
    protected const float crossFadeDuration = 0.1f;

    //Get Animation Hashes
    protected static readonly int ZidleHash = Animator.StringToHash("ZIdle");
    protected readonly int ZwalkHash = Animator.StringToHash("ZWalk");
    protected readonly int ZrunHash = Animator.StringToHash("ZRun");
    protected readonly int ZattackHash = Animator.StringToHash("ZAttack");
    protected readonly int ZdieHash = Animator.StringToHash("ZDie");


    protected EnemyBaseState(Enemy enemy, Animator animator)
    {
        this.enemy = enemy;
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