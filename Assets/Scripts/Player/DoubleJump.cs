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
        Debug.Log(_jump);
        return _jump.CanJump() || _canDoubleJump;
    }
    private void Update()
    {
        if (_jump == null) return;
        Debug.Log(CanJump());
    }
    public void Jump()
    {
        if (CheckGround.isGrounded)
            _canDoubleJump = true;
        else
            _canDoubleJump = false;

        _jump.Jump();
    }
}
