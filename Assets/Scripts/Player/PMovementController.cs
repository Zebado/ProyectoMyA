using UnityEngine;

[RequireComponent(typeof(PInputManager))]
public class PMovementController : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _speed;
    Rigidbody2D _rgbd;
    PInputManager _managerInput;
    IJump _jump;

    private void Awake()
    {
        _rgbd = GetComponent<Rigidbody2D>();
        _managerInput = GetComponent<PInputManager>();
        _jump = GetComponent<IJump>();
    }
    private void OnEnable()
    {
        _managerInput.OnMoveRight += MoveRight;
        _managerInput.OnMoveLeft += MoveLeft;
        _managerInput.OnJump += Jump;
        _managerInput.OnInputStopped += StopMove;

    }
    private void OnDisable()
    {
        _managerInput.OnMoveRight -= MoveRight;
        _managerInput.OnMoveLeft -= MoveLeft;
        _managerInput.OnJump -= Jump;
        _managerInput.OnInputStopped -= StopMove;
    }

    private void MoveLeft()
    {
        _rgbd.velocity = new Vector2(-_speed, _rgbd.velocity.y);
    }

    private void MoveRight()
    {
        _rgbd.velocity = new Vector2(_speed, _rgbd.velocity.y);
    }
    private void StopMove()
    {
        _rgbd.velocity = new Vector2(0, _rgbd.velocity.y);
    }
    void Jump()
    {
        _jump.Jump();
    }
    public void AddDoubleJump()
    {
        DoubleJump doubleJump = gameObject.AddComponent<DoubleJump>();
        doubleJump.Initialize(_jump);
        _jump = doubleJump;
    }
}
