using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAnimationController : MonoBehaviour
{
    [SerializeField] Animator _animatior;

    private void OnEnable()
    {
        PInputManager.OnInputReceived += PlayAnimationRun;
        PInputManager.OnInputReceived += PlayAttack;
        PInputManager.OnInputStopped += StopAnimationRun;
    }

    private void PlayAnimationRun(KeyCode key)
    {
        if (key == KeyCode.D || key == KeyCode.A)
        {
            _animatior.SetInteger("AnimState", 1);
        }
    }
    void StopAnimationRun()
    {
        _animatior.SetInteger("AnimState", 0);
    }
    void PlayAttack(KeyCode key)
    {
        if (key == KeyCode.K)
        {
            _animatior.SetBool("Attack1", true);
        }
    }
    private void OnDisable()
    {
        PInputManager.OnInputReceived -= PlayAnimationRun;
        PInputManager.OnInputStopped -= StopAnimationRun;

    }
}
