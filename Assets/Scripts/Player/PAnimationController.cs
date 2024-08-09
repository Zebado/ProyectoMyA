using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PInputManager))]
public class PAnimationController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    PInputManager _managerInput;
    SpriteRenderer _spriteRenderer;
    bool _isDead;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _managerInput = GetComponent<PInputManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _isDead = false;
    }
    private void OnEnable()
    {
        _managerInput.OnMoveRight += MoveRight;
        _managerInput.OnMoveLeft += MoveLeft;
        _managerInput.OnInputStopped += StopAnimationRun;
        _managerInput.OnJump += JumpAnimation;
        _managerInput.OnAttack += AttackAnimation;
        EventManager.SusbcribeToEvent(EventsType.Event_PlayerDead, OnPlayerDead);
        EventManager.SusbcribeToEvent(EventsType.Event_SubstractLife, HurtAnimation);
    }

    private void StartAnimationRun()
    {
        _animator.SetInteger("AnimState", 1);
    }
    void StopAnimationRun()
    {
        _animator.SetInteger("AnimState", 0);
    }
    void DeathAnimation()
    {
        if (_animator != null)
        {
            _animator.SetTrigger("Death");
            _isDead = true;
        }
    }
    void HurtAnimation(params object[] parameters)
    {
        if (_isDead) return;
        _animator.SetTrigger("Hurt");
    }
    void AttackAnimation()
    {
        _animator.SetBool("Attack1", true);
    }
    void JumpAnimation()
    {
        _animator.SetBool("Jump", true);
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
            gameObject.transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (direction == 1)
        {
            gameObject.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
    private void OnPlayerDead(params object[] parameters)
    {
        DeathAnimation();
    }
    private void OnDisable()
    {
        _managerInput.OnMoveRight -= StartAnimationRun;
        _managerInput.OnMoveLeft -= StartAnimationRun;
        _managerInput.OnInputStopped -= StopAnimationRun;
        _managerInput.OnJump -= JumpAnimation;
        EventManager.UnsusbcribeToEvent(EventsType.Event_PlayerDead, OnPlayerDead);
        EventManager.UnsusbcribeToEvent(EventsType.Event_SubstractLife, HurtAnimation);
    }
}
