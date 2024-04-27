using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PInputManager : MonoBehaviour
{
    public delegate void InputDetected();
    public static event InputDetected OnMoveRight;
    public static event InputDetected OnMoveLeft;
    public static event InputDetected OnJump;

    public delegate void AnimationAction();
    public static event AnimationAction OnStartRunAnimation;
    public static event AnimationAction OnStopRunAnimation;
    public static event AnimationAction OnAttack;

    public delegate void InputDisable();
    public static event InputDisable OnInputStopped;

    LifePlayerHandler _lifeplayer;
    bool _isRight { get; set; }
    private void Awake()
    {
        _lifeplayer = GetComponent<LifePlayerHandler>();
    }
    void Update()
    {
        DetectInputs();
    }

    void DetectInputs()
    {
        if (_lifeplayer._onDead == true) return;
        if (Input.GetKey(KeyCode.D))
        {
            _isRight = true;
            OnMoveRight?.Invoke();
            OnStartRunAnimation?.Invoke();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _isRight = false;
            OnMoveLeft?.Invoke();
            OnStartRunAnimation?.Invoke();
        }
        if (Input.GetKey(KeyCode.W))
        {
            OnJump?.Invoke();
        }
        else if (Input.GetKey(KeyCode.S))
        {

        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            OnInputStopped?.Invoke();
            OnStopRunAnimation?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {

        }
    }
}

