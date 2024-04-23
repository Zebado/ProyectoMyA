using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAnimationController : MonoBehaviour
{
    [SerializeField] Animator _animatior;
    private void Start()
    {
        PInputManager.OnInputReceived += PlayAnimation;
    }

    private void PlayAnimation(KeyCode key)
    {
        if(KeyCode.D == key)
        {
            _animatior.SetInteger("AnimState", 1);
        }
    }
}
