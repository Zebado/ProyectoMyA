using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{

    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] int _initialAmount;
    Pool<Bullet> _bulletPool;
    public static BulletFactory Instance { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

       _bulletPool = new Pool<Bullet>(CreateObject, Bullet.TurnOn, Bullet.TurnOff, _initialAmount);
    }

    Bullet CreateObject()
    {
        return Instantiate(_bulletPrefab);
    }
    public Bullet GetObjectFromPool()
    {
        return _bulletPool.GetObject();
    }
    public void ReturnObjectToPool(Bullet obj)
    {
        _bulletPool.ReturnObjectToPool(obj);
    }
}
