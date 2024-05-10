using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    Pool<Bullet> _bulletPool;


    private void Awake()
    {
       // _bulletPool = new Pool<Bullet>();
    }
}
