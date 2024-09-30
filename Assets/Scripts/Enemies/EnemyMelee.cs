using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyBase
{
    public Transform pointA;
    public Transform pointB;
    private void Start()
    {
        race = EnemyRace.Melee;
        enemyState = new EnemyState();
        enemyState.ChangeState(new PatrolState(pointA, pointB), this);
    }

    private void Update()
    {
        if (!isDead)
            enemyState.Update();
    }
    public override void Attack()
    {
        if (!isDead)
            _enemyAnimatior.AttackAnimation();
    }
    public void SetPatrolPoints(Transform pointA, Transform pointB)
    {
        this.pointA = pointA;
        this.pointB = pointB;
    }
}
