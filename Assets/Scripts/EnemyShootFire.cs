using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootFire : MonoBehaviour
{
    [SerializeField] Bullet _bulletPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            var bullet = Instantiate(_bulletPrefab);

            bullet.transform.position = this.transform.position;
        }
    }
}
