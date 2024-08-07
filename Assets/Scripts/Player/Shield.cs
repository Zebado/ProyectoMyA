using UnityEngine;

public class Shield : MonoBehaviour, ILife
{
     ILife _life;
     int _shieldPoints;
    GameObject _shieldObject;
    LifePlayerHandler _playerHandler;

    public void Initialize(ILife life, int shieldPoints, GameObject shieldVisualPrefab,LifePlayerHandler playerHandler)
    {
        _life = life;
        _shieldPoints = shieldPoints;
        _shieldObject = Instantiate(shieldVisualPrefab, transform);
        _shieldObject.SetActive(true);
        _playerHandler = playerHandler;

        EventManager.SusbcribeToEvent(EventsType.Event_SubstractLife, OnDamageTaken);
        _playerHandler.SetInvulnerable(true);
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
        if (_shieldPoints > 0)
        {
            int damageAbsorbed = Mathf.Min(amount, _shieldPoints);
            _shieldPoints -= damageAbsorbed;
            amount -= damageAbsorbed;
            if (_shieldPoints <= 0)
            {
                _shieldObject.SetActive(false);
                _playerHandler.SetInvulnerable(false);
            }
        }
        if (amount > 0)
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
