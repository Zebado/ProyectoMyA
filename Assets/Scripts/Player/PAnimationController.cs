using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAnimationController : MonoBehaviour
{
    [SerializeField] Animator _animatior;

    private void OnEnable()
    {
        PInputManager.OnStartRunAnimation += StartAnimationRun;
        PInputManager.OnStopRunAnimation += StopAnimationRun;
        PInputManager.OnAttack += PlayAttack;
        PInputManager.OnJump += JumpAnimation;
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
    private void OnDisable()
    {
        PInputManager.OnStartRunAnimation -= StartAnimationRun;
        PInputManager.OnStopRunAnimation -= StopAnimationRun;
        PInputManager.OnAttack -= PlayAttack;
    }
}
