using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PInputManager : MonoBehaviour
{
    public event Action InputDetected;
    void Update()
    {
        DetectInputs();
    }

    void DetectInputs()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {

        }
      
    }
}

public class MovementPlayer : MonoBehaviour
{

}

public class AnimationPlayer : MonoBehaviour
{

}

