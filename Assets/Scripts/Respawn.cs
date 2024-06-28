using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] Transform _respawnPoint;
    GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //_player.transform.position = _respawnPoint.transform.position;
            _gameManager.LoadCheckPoint();
        }
    }
}
