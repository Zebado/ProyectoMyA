using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : EnemyBase
{
    private void Start()
    {
        enemyState = new EnemyState();
        enemyState.ChangeState(new IdleState(), this);
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
