using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PInputManager : MonoBehaviour
{
    public delegate void InputDetected(KeyCode key);
    public static event InputDetected OnInputReceived;

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
            OnInputReceived?.Invoke(KeyCode.D);          
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _isRight = false;
            OnInputReceived?.Invoke(KeyCode.A);
        }
        if (Input.GetKey(KeyCode.W))
        {
            OnInputReceived?.Invoke(KeyCode.W);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            OnInputReceived?.Invoke(KeyCode.S);
        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            OnInputStopped?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            OnInputReceived?.Invoke(KeyCode.K);
        }
    }
}

