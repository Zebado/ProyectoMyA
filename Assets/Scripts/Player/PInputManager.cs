using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PInputManager : MonoBehaviour
{
    public delegate void InputDetected(KeyCode key);

    public static event InputDetected OnInputReceived;
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
    }
}

