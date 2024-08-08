using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _timeLine = 3;
    float _currentLifeTime;
    [SerializeField] float _speed;
    [field:SerializeField] public EnumBullet type { get; private set; }

    private void OnEnable()
    {
        _currentLifeTime = 0;
    }
    void Update()
    {
        transform.Translate(-Vector3.right * _speed * Time.deltaTime);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        BulletFactory.Instance.ReturnObjectToPool(this);
        TurnOff(this);
    }
}
