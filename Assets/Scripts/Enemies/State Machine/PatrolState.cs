using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : Entity
{
    Transform _targetA;
    Transform _targetB;
    bool _moveTo;
    EnemyMelee _enemy;

    public PatrolState(Transform targetA, Transform targetB)
    {
        _targetA = targetA;
        _targetB = targetB;
        _moveTo = true;
    }

    public void Enter(EnemyBase enemy)
    {
        _enemy = enemy as EnemyMelee;
    }

    public void Execute()
    {
        if (_enemy == null) return;

        Vector2 target = _moveTo ? _targetA.position : _targetB.position;
        _enemy.MoveTowards(target);

        if (Vector2.Distance(_enemy.transform.position, target) < 0.5f)
            _moveTo = !_moveTo;
        if (_enemy.IsPlayerInRange(_enemy.chaseRange))
        {
            _enemy.enemyState.ChangeState(new ChaseState(), _enemy);
        }
    }

    public void Exit()
    {
        
    }
}
