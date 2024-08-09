using UnityEngine;

public class Shield : MonoBehaviour, ILife
{
    ILife _life;
    bool _shieldActive;
    GameObject _shieldObject;
    LifePlayerHandler _playerHandler;

    public void Initialize(ILife life, GameObject shieldVisualPrefab, LifePlayerHandler playerHandler)
    {
        _life = life;
        _shieldActive = true;
        _shieldObject = Instantiate(shieldVisualPrefab, transform);
        _shieldObject.SetActive(true);
        _playerHandler = playerHandler;

        _playerHandler.SetInvulnerable(true);
        _playerHandler.SetShieldInvulnerable(true);

        EventManager.SusbcribeToEvent(EventsType.Event_SubstractLife, OnDamageTaken);
    }
    private void OnDamageTaken(params object[] parameters)
    {
        if (parameters.Length > 0 && parameters[0] is int damage)
        {
            TakeDamage(damage);
        }
    }
    private void OnDestroy()
    {
        EventManager.UnsusbcribeToEvent(EventsType.Event_SubstractLife, OnDamageTaken);
        if (_playerHandler != null)
        {
            _playerHandler.SetInvulnerable(false);
        }
    }
    public void TakeDamage(int amount)
    {
        if (_shieldActive)
        {
            _shieldActive = false;
            _shieldObject.SetActive(false);
            _playerHandler.SetShieldInvulnerable(false);
            _playerHandler.SetInvulnerable(false);
        }
        else
        {
            _life.TakeDamage(amount);
        }
    }

    public int GetCurrentLife()
    {
        return _life.GetCurrentLife();
    }

    public int GetMaxLife()
    {
        return _life.GetMaxLife();
    }
}
