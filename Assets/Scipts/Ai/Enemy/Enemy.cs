using System;
using UnityEngine;
using UnityEngine.AI;



[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : Entity 
{
    [SerializeField, Self] NavMeshAgent agent;
    [SerializeField, Child] Animator animator;
    [SerializeField] float wanderRadius = 10f;
    StateMachine stateMachine;

   
    void Start()
    {
        stateMachine = new StateMachine();
        var wanderState = new EnemyWanderState(enemy:this,animator,agent,wanderRadius:5f);
        Any(wanderState,condition: new FuncPredicate(()=>true));
        stateMachine.SetState(wanderState);
    }

    void At(IState from, IState to, IPredicate condition) => stateMachine.AddTransition(from, to, condition);
    void Any(IState to, IPredicate condition) => stateMachine.AddAnyTransition(to, condition);

    void Update()
    {   
        stateMachine.Update();
    }
    void FixedUpdate()
    {
        stateMachine.FixedUpdate();

    }
}
