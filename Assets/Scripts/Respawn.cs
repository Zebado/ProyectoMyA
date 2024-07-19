using UnityEngine;

public class Respawn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<MementoPlayer>();
        if (player != null)
            GameManager.Instance.LoadCheckPoint();
    }
}
