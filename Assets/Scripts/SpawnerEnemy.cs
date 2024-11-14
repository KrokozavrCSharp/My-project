using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _time;

    private int _defaultCapacity = 25;
    private int _maxSize = 3;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(
              createFunc: () => Instantiate(_enemy),
            actionOnGet: (enemy) => OnGet(enemy),
            actionOnRelease: (enemy) => enemy.gameObject.SetActive(false),
            actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
            collectionCheck: true,
            defaultCapacity: _defaultCapacity,
            maxSize: _maxSize
            );
    }

    private void Start()
    {
        StartCoroutine(Spawn(_time));
    }

    private void OnGet(Enemy enemy)
    {
        enemy.transform.position = gameObject.transform.position;

        enemy.gameObject.SetActive(true);
        
        enemy.Initialize(_target);    
    }

    private IEnumerator Spawn(float time)
    {
        var delay = new WaitForSecondsRealtime(time);

        while (true)
        {
            _pool.Get();

            yield return delay;
        }
    }
}