using UnityEngine;

public class EnemyShootFire : MonoBehaviour
{
    float _CurrentTime;
    float _maxTime = 3;
    [SerializeField] Transform _point;

    private void Awake()
    {
        _CurrentTime = 0;
    }
    void Update()
    {
        _CurrentTime += Time.deltaTime;

        if (_CurrentTime >= _maxTime)
        {
            _CurrentTime = 0;
            var bullet = BulletFactory.Instance.GetObjectFromPool(EnumBullet.FireBullet);    
            bullet.transform.position = _point.transform.position;
        }
    }
}
