using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : Entity
{
    Vector2 _targetA;
    Vector2 _targetB;
    bool _moveTo;
    EnemyBase _enemy;

    public PatrolState(Vector2 targetA, Vector2 targetB)
    {
        _targetA = targetA;
        _targetB = targetB;
        _moveTo = true;
    }
    public void Enter(EnemyBase enemy)
    {
        enemy = _enemy;
    }

    public void Execute()
    {
        Vector2 target = _moveTo ? _targetA : _targetB;
        _enemy.MoveTowards(target);

        if (Vector2.Distance(_enemy.transform.position, target) < 0.1f)
            _moveTo = !_moveTo;
    }

    public void Exit()
    {
        
    }
}
