using UnityEngine;

public class PInputManager : MonoBehaviour
{
    public delegate void InputDetected();
    public event InputDetected OnMoveRight;
    public event InputDetected OnMoveLeft;
    public event InputDetected OnJump;

    public delegate void InputDisable();
    public event InputDisable OnInputStopped;

    LifePlayerHandler _lifeplayer;
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            OnMoveLeft?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            OnMoveRight?.Invoke();

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
        }
        else if (Input.GetKey(KeyCode.S))
        {

        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            OnInputStopped?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {

        }
    }
}

