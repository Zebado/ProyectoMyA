using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PInputManager : MonoBehaviour
{
    public delegate void InputDetected(KeyCode key);
    public delegate void InputDisable();

    public static event InputDetected OnInputReceived;
    public static event InputDisable OnInputStopped;
    void Update()
    {
        DetectInputs();
    }

    void DetectInputs()
    {

        if (Input.GetKey(KeyCode.D))
        {
            OnInputReceived?.Invoke(KeyCode.D);          
        }
        else if (Input.GetKey(KeyCode.A))
        {
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
    }
}

