using UnityEngine;

public class LifePlayerHandler : MonoBehaviour
{
    public int currentLife { get; private set; }
    public int lifeMax { get; private set; } = 3;
    public bool _onDead { get; private set; }

    bool _potionTaken = false;

    private void OnEnable()
    {
        EventManager.SusbcribeToEvent(EventsType.Event_SubstractLife, SubstractLifeDelegate);
        EventManager.SusbcribeToEvent(EventsType.Event_RecoverLife, RecoverLife);
    }

    private void Awake()
    {
        currentLife = lifeMax;
        _onDead = false;
    }

    private void SubstractLifeDelegate(params object[] parameters)
    {
        if (parameters.Length > 0 && parameters[0] is int)
        {
            int damage = (int)parameters[0];
            SubstractLife(damage);
        }
    }
    private void SubstractLife(int damage)
    {
        currentLife -= damage > 1 ? damage : 1;
        if (currentLife <= 0)
        {
            Ondead();
        }
        else
        {
            EventManager.TriggerEvent(EventsType.Event_PlayerLifeChanged, currentLife);
        }
    }
    private void RecoverLife(params object[] parameters)
    {
        currentLife += (int)parameters[0];
        EventManager.TriggerEvent(EventsType.Event_PlayerLifeChanged, currentLife);
    }

    public void Ondead()
    {
        _onDead = true;
        EventManager.TriggerEvent(EventsType.Event_PlayerDead);
    }
    private void OnDisable()
    {
        EventManager.UnsusbcribeToEvent(EventsType.Event_RecoverLife, RecoverLife);
        EventManager.UnsusbcribeToEvent(EventsType.Event_SubstractLife, SubstractLifeDelegate);
    }

    public bool IsPotionTaken()
    {
        return _potionTaken;
    }

    public void SetPotionTaken(bool value)
    {
        _potionTaken = value;
    }
}
