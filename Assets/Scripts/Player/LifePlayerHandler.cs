using UnityEngine;

public class LifePlayerHandler : MonoBehaviour, ILife
{
    public int currentLife { get; private set; }
    public int LifeMax { get; private set; } = 3;
    public bool _onDead { get; private set; }

    bool _potionTaken = false;

    float _damageTime;
    float _damageTimeMax;
    bool _isInvulnerable;
    bool _isShield;
    [SerializeField] GameObject _hud;

    private void OnEnable()
    {
        EventManager.SusbcribeToEvent(EventsType.Event_SubstractLife, SubstractLifeDelegate);
        EventManager.SusbcribeToEvent(EventsType.Event_RecoverLife, RecoverLife);
    }

    private void Awake()
    {
        _onDead = false;
        _isInvulnerable = false;
        _damageTime = 0;
        _damageTimeMax = 1;
    }
    private void Start()
    {
        if (currentLife == 0)
        {
            setMaxLife();
        }
    }
    private void Update()
    {
        if (_isShield) return;
        if (_isInvulnerable)
        {
            _damageTime += Time.deltaTime;
            if (_damageTime > _damageTimeMax)
            {
                _isInvulnerable = false;
                _damageTime = 0;
            }
        }
    }
    public void SetShieldInvulnerable(bool value)
    {
        _isShield = value;
    }
    public void setMaxLife()
    {
        currentLife = LifeMax;
    }
    public void ActiveHud()
    {
        _hud.SetActive(true);
    }
    private void SubstractLifeDelegate(params object[] parameters)
    {
        if (parameters.Length > 0 && parameters[0] is int damage)
        {
            SubstractLife(damage);
        }
    }
    //private void SubstractLife(int damage)
    //{
    //    if (_isInvulnerable || _isShield || _onDead) return;
    //    Debug.Log("da�o recibido" + damage);
    //    currentLife -= Mathf.Max(damage, 1);
    //    _isInvulnerable = true;
    //    if (currentLife <= 0)
    //    {
    //        Ondead();
    //    }
    //}
    private (int currentLife, bool isInvulnerable) SubstractLife(int damage) //tupla 
    {
        //if (_isInvulnerable || _isShield || _onDead) return (currentLife, _isInvulnerable);

        if (_isShield)
        {
            _isShield = false; 
            _isInvulnerable = true;
            return (currentLife, _isInvulnerable);
        }

        currentLife -= Mathf.Max(damage, 1);
        _isInvulnerable = true;

        if (currentLife <= 0)
        {
            Ondead();
        }

        return (currentLife, _isInvulnerable);
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
    public void SetCurrentLife(int life)
    {
        Debug.Log($"SetCurrentLife llamado: Vida actual: {currentLife}, Nueva vida: {life}");
        currentLife = life;
        if (currentLife <= 0)
        {
            Ondead();
        }
    }

    public void TakeDamage(int amount)
    {
        currentLife -= amount;
        if (currentLife < 0) currentLife = 0;
    }

    public int GetCurrentLife()
    {
        if (currentLife == 0)
        {
            return LifeMax;
        }
        return currentLife;
    }

    public int GetMaxLife()
    {
        return LifeMax;
    }
    public void SetInvulnerable(bool value)
    {
        _isInvulnerable = value;
    }
}
