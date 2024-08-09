using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : Entity
{
    EnemyBase _enemy;
    public void Enter(EnemyBase enemy)
    {
        _enemy = enemy;
    }

    public void Execute(EnemyBase enemy)
    {
        if (enemy == null || enemy.isDead) return;
        if (_enemy == null) return;
        if (_enemy.IsPlayerInRange(_enemy.attackRange))
        {
            _enemy.Attack();
        }
        else
        {
            if (_enemy is EnemyMelee enemyMelee)
            {

                if (_enemy.IsPlayerInRange(enemyMelee.chaseRange))
                {
                    _enemy.enemyState.ChangeState(new ChaseState(), _enemy);
                }
                else
                {
                    _enemy.enemyState.ChangeState(new PatrolState(enemyMelee.pointA, enemyMelee.pointB), _enemy);
                }
            }
            else if (_enemy is RangeEnemy rangeEnemy)
            {
                if (_enemy.IsPlayerInRange(rangeEnemy.attackRange))
                {
                    _enemy.enemyState.ChangeState(new IdleState(), _enemy);
                }
                else
                {
                    _enemy.enemyState.ChangeState(new IdleState(), _enemy);
                }
            }
        }
    }
    public void Exit()
    {
    }
}
