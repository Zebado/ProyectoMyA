using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    private Entity _currentState;
    private EnemyBase _enemy;
    public void ChangeState(Entity newState, EnemyBase enemy)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }
        _currentState = newState;
        _enemy = enemy;
        _currentState.Enter(enemy);
    }

    public void Update()
    {
        if (_enemy != null && !_enemy.isDead && _currentState != null)
        {
            _currentState.Execute(_enemy);
        }
    }
}
