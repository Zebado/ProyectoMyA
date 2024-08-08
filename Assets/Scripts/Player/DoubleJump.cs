using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour, IJump
{
    IJump _jump;
    bool _canDoubleJump = false;

    public void Initialize(IJump jump)
    {
        _jump = jump;
    }
    public bool CanJump()
    {
        return CheckGround.isGrounded || _canDoubleJump;
    }

    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            _jump.Jump();
            _canDoubleJump = true;
        }
        else if (_canDoubleJump)
        {
            _jump.Jump();
            _canDoubleJump = false;
        }
    }
}
