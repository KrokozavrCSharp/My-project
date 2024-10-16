using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerCrabs : MonoBehaviour
{
    [SerializeField] private Crab _enemy;
    [SerializeField] private float _time;

    private int _defaultCapacity = 25;
    private int _maxSize = 3;

    private ObjectPool <Crab> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Crab>(
              createFunc: () => Instantiate(_enemy),
            actionOnGet: (crab) => OnGet(crab),
            actionOnRelease: (crab) => OnRelease(crab),
            actionOnDestroy: (crab) => Destroy(crab.gameObject),
            collectionCheck: true,
            defaultCapacity: _defaultCapacity,
            maxSize: _maxSize
            );
    }

    private void Start()
    {
        StartCoroutine(Spawn(_time));
    }

    private void OnGet(Crab crab)
    {
        crab.transform.position = gameObject.transform.position;
        SetDirection();
        crab.gameObject.SetActive( true );
    }

    private void OnRelease(Crab crab)
    {
        crab.gameObject.SetActive(false);

        ReturnCube(crab);
    }

    private void SetDirection()
    {
        float permamentdirection = 0;
        float minPosition = 0;
        float maxPosition = 361;
        float positionY = UnityEngine.Random.Range(minPosition, maxPosition);

        _enemy.transform.rotation *= Quaternion.Euler(permamentdirection, positionY, permamentdirection);
    }

    private void ReturnCube(Crab crab)
    {
        _pool.Release(crab);
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