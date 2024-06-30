using UnityEngine;

public class Respawn : MonoBehaviour
{
    GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameManager.LoadCheckPoint();
        }
    }
}
