using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPowerUp : MonoBehaviour
{
    public GameObject powerUpJumpDouble;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        EnableDoubleJump(collision.gameObject);
        gameObject.SetActive(false);
    }

    private void EnableDoubleJump(GameObject player)
    {
        PMovementController movController = player.GetComponent<PMovementController>();
        if(movController != null)
        {
            movController.AddDoubleJump();
        }
    }
}
