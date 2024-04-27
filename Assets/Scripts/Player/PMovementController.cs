using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovementController : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    Rigidbody2D _rgbd;

    private void Awake()
    {
        _rgbd = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        PInputManager.OnMoveRight += MoveRight;
        PInputManager.OnMoveLeft += MoveLeft;
        PInputManager.OnJump += Jump;
    }
    private void OnDisable()
    {
        PInputManager.OnMoveRight -= MoveRight;
        PInputManager.OnMoveLeft -= MoveLeft;
        PInputManager.OnJump -= Jump;
    }
   
    private void MoveLeft()
    {

        _rgbd.velocity = new Vector2(-_speed, _rgbd.velocity.y);
        OrientPlayer(KeyCode.A);
    }

    private void MoveRight()
    {
        _rgbd.velocity = new Vector2(_speed, _rgbd.velocity.y);
        OrientPlayer(KeyCode.D);
    }
   
    void Jump()
    {
        _rgbd.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    void OrientPlayer(KeyCode key)
    {
        if (key == KeyCode.A && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (key == KeyCode.D && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
   
}
