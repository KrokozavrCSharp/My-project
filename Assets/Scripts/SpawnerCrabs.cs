using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerCrabs : MonoBehaviour
{
    [SerializeField] private Crab _enemy;
    [SerializeField] private float _time;

    private int _defaultCapacity = 25;
    private int _maxSize = 3;

    private ObjectPool<Crab> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Crab>(
              createFunc: () => Instantiate(_enemy),
            actionOnGet: (crab) => OnGet(crab),
            actionOnRelease: (crab) => crab.gameObject.SetActive(false),
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

    private Vector3 GetDirection()
    {
        float permamentdirection = 0;
        float minPosition = 0;
        float maxPosition = 360;
        float positionZ = UnityEngine.Random.Range(minPosition, maxPosition);
        float positionX = UnityEngine.Random.Range(minPosition, maxPosition);

        Vector3 direction = new Vector3(positionX, permamentdirection, positionZ);

        return direction;
    }

    private void OnGet(Crab crab)
    {
        crab.transform.position = gameObject.transform.position;
        crab.gameObject.SetActive(true);

        if (crab.TryGetComponent<Crab>(out crab))
        {
            crab.Initialize(GetDirection());
        }
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