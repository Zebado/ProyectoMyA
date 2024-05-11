using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player")) return;

        if (!collision.TryGetComponent(out LifePlayerHandler lifeHandler)) return;

        if (lifeHandler.IsPotionTaken()) return;

        if (lifeHandler.currentLife >= lifeHandler.lifeMax) return;

        lifeHandler.SetPotionTaken(true);

        EventManager.TriggerEvent(EventsType.Event_RecoverLife,1);

        lifeHandler.SetPotionTaken(false);

        Destroy(gameObject);
    }
}
