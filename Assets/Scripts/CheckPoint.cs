using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckPoint : MonoBehaviour
{
    bool _IsTrigger;
    PInputManager _inputManager;
    private void OnEnable()
    {
        _inputManager.OnCheckPoint += CheckPointOn;
    }
    private void OnDisable()
    {
        _inputManager.OnCheckPoint -= CheckPointOn; 
    }
    private void Awake()
    {
        _inputManager = FindAnyObjectByType<PInputManager>();
    }
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
