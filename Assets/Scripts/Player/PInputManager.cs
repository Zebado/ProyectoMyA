using UnityEngine;

public class PInputManager : MonoBehaviour
{
    public delegate void InputDetected();
    public event InputDetected OnMoveRight;
    public event InputDetected OnMoveLeft;
    public event InputDetected OnJump;
    public event InputDetected OnCheckPoint;

    public delegate void InputDisable();
    public event InputDisable OnInputStopped;

    LifePlayerHandler _lifeplayer;
    GameManager _gm;
    bool isWinGame;
    private void Awake()
    {
        _lifeplayer = GetComponent<LifePlayerHandler>();
    }
    void Update()
    {
        if (_gm != null)
        {
            isWinGame = _gm.winGame;
        }
        if (isWinGame) return;
        DetectInputs();
    }

    void DetectInputs()
    {
        if (_lifeplayer._onDead == true)
        {
            OnInputStopped?.Invoke();
            return;
        }

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
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            OnInputStopped?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnCheckPoint?.Invoke();
        }
    }
}

