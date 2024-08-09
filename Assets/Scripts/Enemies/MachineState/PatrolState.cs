using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : Entity
{
    Transform _pointA;
    Transform _pointB;
    bool _moveTo;

    public PatrolState(Transform pointA, Transform pointB)
    {
        _pointA = pointA;
        _pointB = pointB;
    }

    public void Enter(EnemyBase enemy)
    {
    }

    public void Execute(EnemyBase enemy)
    {
        if (enemy == null || enemy.isDead) return;
        if (enemy.IsPlayerInRange(enemy.attackRange))
        {
            enemy.enemyState.ChangeState(new AttackState(), enemy);
            return;
        }
        if (enemy.IsPlayerInRange(enemy.chaseRange))
        {
            enemy.enemyState.ChangeState(new ChaseState(), enemy);
            return;
        }
        Transform targetPoint = _moveTo ? _pointB : _pointA;
        enemy.MoveTowards(targetPoint.position);

        if (Vector2.Distance(enemy.transform.position, targetPoint.position) < 0.5f)
        {
            _moveTo = !_moveTo;
        }

        
    }

    public void Exit()
    {
        
    }
}
