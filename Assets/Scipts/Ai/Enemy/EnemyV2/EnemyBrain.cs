using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyBrain : MonoBehaviour
{
    public Transform target;
    public EnemyReferences enemyReferences;
    private float attackingDistance;
    private float pathUpdateDeadLine;


    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
    }
    void Start()
    {
        attackingDistance = enemyReferences.navMeshagent.stoppingDistance;
    }
    void Update()
    {
        if(target != null) { 
        bool inRange = Vector3.Distance(transform.position, target.position)<= attackingDistance;
            if (inRange)
            {
                LookAtTarget();
            }
            else
            {
                UpdatePath();
            }
            enemyReferences.animator.SetBool("attack", inRange);
        }
        enemyReferences.animator.SetFloat("speed", enemyReferences.navMeshagent.desiredVelocity.sqrMagnitude);
    }
    private void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation= Quaternion.Slerp(transform.rotation, rotation,0.2f);

    }
    private void UpdatePath()
    {
        if(Time.time>= pathUpdateDeadLine){
            pathUpdateDeadLine = Time.time+enemyReferences.pathUpdateDelay;
            enemyReferences.navMeshagent.SetDestination(target.position);
        }

    }
}
