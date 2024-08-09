using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public GameObject shieldVisualPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player")) return;

        if (!collision.TryGetComponent(out LifePlayerHandler lifeHandler)) return;

        Shield shieldDecorator = collision.gameObject.AddComponent<Shield>();
        shieldDecorator.Initialize(lifeHandler, shieldVisualPrefab, lifeHandler);
        gameObject.SetActive(false);
    }
}
