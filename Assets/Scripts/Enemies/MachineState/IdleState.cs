using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : Entity
{
    EnemyBase _enemy;
    public void Enter(EnemyBase enemy)
    {
        _enemy = enemy;
    }

    public void Execute(EnemyBase enemy)
    {
        if (enemy == null || enemy.isDead) return;
        if (_enemy.IsPlayerInRange(_enemy.attackRange))
        {
            _enemy.enemyState.ChangeState(new AttackState(), _enemy);
        }
    }

    public void Exit()
    {
        
    }
}
