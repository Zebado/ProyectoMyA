using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField] Bullet _bulletPrefabFire;
    [SerializeField] Bullet _bulletPrefabArrow;
    [SerializeField] int _initialAmount;
    Pool<Bullet> _bulletPoolArrow;
    Pool<Bullet> _bulletPoolFire;
    public static BulletFactory Instance { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        _bulletPoolArrow = new Pool<Bullet>(CreateBulletArrow, Bullet.TurnOn, Bullet.TurnOff, _initialAmount);
        _bulletPoolFire = new Pool<Bullet>(CreateBulletFire, Bullet.TurnOn, Bullet.TurnOff, _initialAmount);
    }

    Bullet CreateBulletArrow()
    {
        return Instantiate(_bulletPrefabArrow);
    }
    Bullet CreateBulletFire()
    {
        return Instantiate(_bulletPrefabFire);
    }
    public Bullet GetObjectFromPool(EnumBullet bullet)
    {
        switch (bullet)
        {
            case EnumBullet.ArrowBullet:
                return _bulletPoolArrow.GetObject();
            case EnumBullet.FireBullet:
                return _bulletPoolFire.GetObject();
        }
        return null;
    }
    public void ReturnObjectToPool(Bullet bullet)
    {
        switch (bullet.type)
        {
            case EnumBullet.ArrowBullet:
                _bulletPoolArrow.ReturnObjectToPool(bullet);
                break;
            case EnumBullet.FireBullet:
                _bulletPoolFire.ReturnObjectToPool(bullet);
                break;
        }
    }
}
