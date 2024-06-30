using UnityEngine;

public class TP : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] Transform _respawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("estoy chocando con" + _player);
            _player.transform.position = _respawnPoint.transform.position;
        }
    }
}
