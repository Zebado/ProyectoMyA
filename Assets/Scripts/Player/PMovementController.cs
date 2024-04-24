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
            OrientPlayer(key);
            MoveHorizontal(-1);
        }
        else if (key == KeyCode.D)
        {
            OrientPlayer(key);
            MoveHorizontal(1);
        }
    }
    void MoveHorizontal(float direction)
    {
        float horizontalMove = direction * _speed * Time.deltaTime;

        _player.Translate(horizontalMove, 0f, 0f);
    }
    void OrientPlayer(KeyCode key)
    {
        if (key == KeyCode.A)
        {
            if (_player.transform.localScale.x != -1)
            {
                _player.transform.localScale = new Vector2(-Mathf.Abs(_player.transform.localScale.x), _player.transform.localScale.y);
            }
        }
        else if (key == KeyCode.D)
        {
            if (_player.transform.localScale.x != 1)
            {
                _player.transform.localScale = new Vector2(Mathf.Abs(_player.transform.localScale.x), _player.transform.localScale.y);
            }
        }
    }
    private void OnDisable()
    {
        PInputManager.OnInputReceived -= HandleInput;
    }
}
