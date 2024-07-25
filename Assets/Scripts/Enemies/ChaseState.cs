using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : Entity
{
    EnemyMelee _enemy;
    public void Enter(EnemyBase enemy)
    {
        _enemy = enemy as EnemyMelee;
    }

    public void Execute()
    {
        if (_enemy == null) return;
        if (_enemy.IsPlayerInRange(_enemy.attackRange))
        {
            _enemy.enemyState.ChangeState(new AttackState(), _enemy);
        }
        else if (_enemy.IsPlayerInRange(_enemy.chaseRange))
        {
            _enemy.MoveTowards(_enemy.PlayerPosition());
        }
        else
            _enemy.enemyState.ChangeState(new PatrolState(_enemy.pointA, _enemy.pointB), _enemy);
    }

    public void Exit()
    {
    }
}
