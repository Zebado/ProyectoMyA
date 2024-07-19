using UnityEngine.SceneManagement;
using UnityEngine;

public class Posion : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer != LayerMask.NameToLayer("Player")) return;

        if (!collision.TryGetComponent(out LifePlayerHandler lifeHandler)) return;

        if (lifeHandler.IsPotionTaken()) return;

        if (lifeHandler.currentLife >= lifeHandler.LifeMax) return;

        lifeHandler.SetPotionTaken(true);

        EventManager.TriggerEvent(EventsType.Event_RecoverLife, 1);

        lifeHandler.SetPotionTaken(false);

        gameObject.SetActive(false);
    }
}

