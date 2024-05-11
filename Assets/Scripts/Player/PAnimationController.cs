using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PInputManager))]

public class PAnimationController : MonoBehaviour
{
    [SerializeField] Animator _animatior;
    PInputManager _managerInput;
    SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _managerInput = GetComponent<PInputManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        _managerInput.OnMoveRight += MoveRight;
        _managerInput.OnMoveLeft += MoveLeft;
        _managerInput.OnInputStopped += StopAnimationRun;
        //_managerInput.OnAttack += PlayAttack;
        _managerInput.OnJump += JumpAnimation;
    }

    private void StartAnimationRun()
    {  
            _animatior.SetInteger("AnimState", 1);       
    }
    void StopAnimationRun()
    {
        _animatior.SetInteger("AnimState", 0);
    }
    void PlayAttack()
    {
            _animatior.SetBool("Attack1", true);
    }
    void JumpAnimation()
    {
        _animatior.SetBool("Jump", true);
    }
    private void MoveLeft()
    {     
        OrientPlayer(-1);
        StartAnimationRun();
    }

    private void MoveRight()
    {
        OrientPlayer(1);
        StartAnimationRun();
    }
    void OrientPlayer(int direction)
    {
        Debug.Log(direction);
        if (direction == -1)
        {
            _spriteRenderer.flipX = true;
        }
        else if (direction == 1)
        {
            _spriteRenderer.flipX = false;
        }
    }
    private void OnDisable()
    {
        _managerInput.OnMoveRight -= StartAnimationRun;
        _managerInput.OnMoveLeft -= StartAnimationRun;
        _managerInput.OnInputStopped -= StopAnimationRun;
        //_managerInput.OnAttack -= PlayAttack;
    }
}
