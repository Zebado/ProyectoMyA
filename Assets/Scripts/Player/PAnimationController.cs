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
        PInputManager.OnInputStopped += StopAnimationRun;
    }

    private void PlayAnimationRun(KeyCode key)
    {
        if (KeyCode.D == key || KeyCode.A == key)
        {
            _animatior.SetInteger("AnimState", 1);
        }
    }
    void StopAnimationRun()
    {
        _animatior.SetInteger("AnimState", 0);
    }
    private void OnDisable()
    {
        PInputManager.OnInputReceived -= PlayAnimationRun;
        PInputManager.OnInputStopped -= StopAnimationRun;

    }
}
