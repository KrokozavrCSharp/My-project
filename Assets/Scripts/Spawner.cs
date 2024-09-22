using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private Vector3 _minPosition;
    [SerializeField] private Vector3 _maxPosition;

    private int _defaultCapacity = 300;
    private int _maxSize = 100;
    private float _repeate = 1f;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (cube) => OnGet(cube),
            actionOnRelease: (cube) => OnRelease(cube),
            actionOnDestroy: (cube) => Destroy(cube),
            collectionCheck: true,
            defaultCapacity: _defaultCapacity,
            maxSize: _maxSize
            );
    }

    private void OnRelease(Cube cube)
    {
        cube.gameObject.SetActive(false);

        cube.Destroyed -= ReturnCube;
    }

    private void Start()
    {
        StartCoroutine(Spawn(_repeate));
    }

    private void OnDisable()
    {
        _prefab.Destroyed -= ReturnCube;
    }

    private void ReturnCube(Cube cube)
    {
        _pool.Release(cube);
    }

    private void OnGet(Cube cube)
    {
        cube.Destroyed += ReturnCube;

        cube.transform.position = GetPosition();

        cube.SetDefaultColor();

        if (cube.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
        {
            rigidbody.velocity = Vector3.zero;
        }

        cube.gameObject.SetActive(true);
    }

    private Vector3 GetPosition()
    {
        Vector3 randomPosition = new Vector3(
            UnityEngine.Random.Range(_minPosition.x, _maxPosition.x),
            _maxPosition.y,
            UnityEngine.Random.Range(_minPosition.z, _maxPosition.z)
            );

        return randomPosition;
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
