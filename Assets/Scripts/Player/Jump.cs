using UnityEngine;

public class Jump : MonoBehaviour, IJump
{
    public float jumpForce = 4.7f;
    Rigidbody2D _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public bool CanJump()
    {
        return CheckGround.isGrounded;
    }

    void IJump.Jump()
    {
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
