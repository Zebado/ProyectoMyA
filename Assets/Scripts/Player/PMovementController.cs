using UnityEngine;

[RequireComponent(typeof(PInputManager))]
public class PMovementController : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    Rigidbody2D _rgbd;
    PInputManager _managerInput;

    private void Awake()
    {
        _rgbd = GetComponent<Rigidbody2D>();
        _managerInput = GetComponent<PInputManager>();
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
        if (CheckGround.isGrounded)
        {
            _rgbd.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
