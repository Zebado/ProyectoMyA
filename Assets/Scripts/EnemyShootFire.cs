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
            Vector2 direction = transform.right;
            if (transform.localScale.x < 0)
            {
                direction = -transform.right;
            }
            if (direction.x > 0)
            {
                bullet.transform.localScale = new Vector3(-Mathf.Abs(bullet.transform.localScale.x), bullet.transform.localScale.y, bullet.transform.localScale.z);
            }
            else
            {
                bullet.transform.localScale = new Vector3(Mathf.Abs(bullet.transform.localScale.x), bullet.transform.localScale.y, bullet.transform.localScale.z);
            }
            bullet.GetComponent<Bullet>().SetDirection(direction);
        }
    }
}
