using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public int shieldPoints = 2;
    public GameObject shieldVisualPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player")) return;

        if (!collision.TryGetComponent(out LifePlayerHandler lifeHandler)) return;

        Shield shieldDecorator = collision.gameObject.AddComponent<Shield>();
        shieldDecorator.Initialize(lifeHandler, shieldPoints, shieldVisualPrefab, lifeHandler);
        gameObject.SetActive(false);
    }
}
