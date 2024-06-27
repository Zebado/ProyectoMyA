using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    bool _IsTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _IsTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _IsTrigger = false;
        }
    }
    public void CheckPointOn()
    {
        if (_IsTrigger)
        {
            GameManager.Instance.SaveCheckPoint();
            Debug.Log("CheckPoint Saved");
        }
    }
}
