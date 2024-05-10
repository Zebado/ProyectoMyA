using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _timeLine;
    float _currentLifeTime;

    void Awake()
    {
        _currentLifeTime = _timeLine;
    }

    void Update()
    {
        _currentLifeTime -= Time.deltaTime;

        if (_currentLifeTime > 0) return;

        Destroy(gameObject);
    }
}
