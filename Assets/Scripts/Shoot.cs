using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _speed;
    [SerializeField] private float _shootDelay;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (enabled)
        {
            var direction = (_enemy.transform.position - transform.position).normalized;
            Bullet bullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            bullet.Init(direction, _speed);

            yield return new WaitForSeconds(_shootDelay);
        }
    }
}
