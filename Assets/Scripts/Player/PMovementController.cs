using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovementController : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _speed;


    private void Start()
    {
        PInputManager.OnInputReceived += HandleInput;
    }
  
    private void HandleInput(KeyCode key)
    {
        if (key == KeyCode.A)
        {
            MoveHorizontal(-1);
        }
        else if (key == KeyCode.D)
        {
            MoveHorizontal(1);
        }
    }
    void MoveHorizontal(float direction)
    {
        float horizontalMove = direction * _speed * Time.deltaTime;

        transform.Translate(horizontalMove, 0f, 0f);
    }
    private void OnDestroy()
    {
        PInputManager.OnInputReceived -= HandleInput;

    }
}
