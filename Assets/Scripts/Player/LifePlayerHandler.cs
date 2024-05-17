using UnityEngine;

public class LifePlayerHandler : MonoBehaviour
{
    public int currentLife { get; private set; }
    public int lifeMax { get; private set; } = 3;
    public bool _onDead { get; private set; }

    bool _potionTaken = false;

    float _damageTime;
    float _damageTimeMax;
    [SerializeField] bool _isInvulnerable;

    private void OnEnable()
    {
        EventManager.SusbcribeToEvent(EventsType.Event_SubstractLife, SubstractLifeDelegate);
        EventManager.SusbcribeToEvent(EventsType.Event_RecoverLife, RecoverLife);
    }

    private void Awake()
    {
        currentLife = lifeMax;
        _onDead = false;
        _isInvulnerable = false;
        _damageTime = 0;
        _damageTimeMax = 3;
    }
    private void Update()
    {
        if (_isInvulnerable)
        {
            _damageTime += Time.deltaTime;
            if (_damageTime > _damageTimeMax)
            {
                _isInvulnerable = false;
            }
        }
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
        if (_isInvulnerable || _onDead) return;
        currentLife -= damage > 1 ? damage : 1;
        _isInvulnerable = true;
        if (currentLife <= 0)
        {
            Ondead();
        }
    }
    private void RecoverLife(params object[] parameters)
    {
        currentLife += (int)parameters[0];
    }

    public void Ondead()
    {
        if (_onDead) return;
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
