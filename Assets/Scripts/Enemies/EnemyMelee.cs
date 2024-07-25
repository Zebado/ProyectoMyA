using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyBase
{
    public float chaseRange;
    public Transform pointA;
    public Transform pointB;
    private void Start()
    {
        enemyState = new EnemyState();
        enemyState.ChangeState(new PatrolState(pointA, pointB), this);
    }

    private void Update()
    {
        enemyState.Update();
    }
    public override void Attack()
    {
        _enemyAnimatior.AttackAnimation();
    }
}
