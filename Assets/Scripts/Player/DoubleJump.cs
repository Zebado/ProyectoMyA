using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour, IJump
{
    IJump _jump;
    public bool doubleJump { get; set; }

    public void Initialize(IJump jump)
    {
        _jump = jump;
        doubleJump = true;
    }
    public bool CanJump()
    {
        return CheckGround.isGrounded || doubleJump;
    }
    public void Jump()
    {
        if (CanJump())
        {
            if (CheckGround.isGrounded)
            {
                _jump.Jump();
                doubleJump = false;
                Debug.Log("deberia ponerse falso");
            }
            else if (doubleJump)
            {
                _jump.Jump();
                doubleJump = false;
            }
        }
    }
}
