using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    private Entity _currentState;

    public void ChangeState(Entity newState, EnemyBase enemy)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }
        _currentState = newState;
        _currentState.Enter(enemy);
    }

    public void Update()
    {
        if (_currentState != null)
        {
            _currentState.Execute();
        }
    }
}
