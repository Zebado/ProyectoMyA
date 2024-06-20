using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGrounded;

    public bool isground = isGrounded;

    private void Update()
    {
        isground = isGrounded;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = true;    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
