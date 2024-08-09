using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _timeLine = 3;
    float _currentLifeTime;
    [SerializeField] float _speed;
    [field:SerializeField] public EnumBullet type { get; private set; }
    Vector2 _direction;

    private void OnEnable()
    {
        _currentLifeTime = 0;
    }
    void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
        _currentLifeTime += Time.deltaTime;
        if (_currentLifeTime <= _timeLine) return;

        BulletFactory.Instance.ReturnObjectToPool(this);
    }
    private void Reset()
    {
        _currentLifeTime = 0;
    }
    public static void TurnOn(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }
    public static void TurnOff(Bullet bullet)
    {
        bullet.Reset();
        bullet.gameObject.SetActive(false);
    }
    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletFactory.Instance.ReturnObjectToPool(this);
        TurnOff(this);
    }
}
