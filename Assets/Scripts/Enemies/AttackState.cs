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

    public void Execute()
    {
        if (_enemy.IsPlayerInRange(_enemy.attackRange))
        {
            _enemy.Attack();
        }
        else
        {
            if(_enemy is EnemyMelee enemyMelee)
            {
                enemyMelee.enemyState.ChangeState(new ChaseState(), enemyMelee);
            }
            else if(_enemy is RangeEnemy rangeEnemy)
            {
                rangeEnemy.enemyState.ChangeState(new IdleState(), rangeEnemy);
            }
        }
    }

    public void Exit()
    {

    }


}
