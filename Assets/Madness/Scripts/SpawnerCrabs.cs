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

    public Vector3 SetDirection()
    {
        float permamentdirection = 0;
        float minPosition = 0;
        float maxPosition = 361;
        float positionY = UnityEngine.Random.Range(minPosition, maxPosition);

        Vector3 direction = new Vector3(permamentdirection, positionY, permamentdirection);

        return direction;
    }

    private void OnGet(Crab crab)
    {
        crab.transform.position = gameObject.transform.position;
        crab.gameObject.SetActive(true);
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