using System;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private Vector3 _minPosition;
    [SerializeField] private Vector3 _maxPosition;

    private int _defaultCapacity = 100;
    private int _maxSize = 100;
    private float _time = 0.0f;
    private float _repeate = 1f;


    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj)=> ActionOnGet(obj),
            actionOnRelease: (obj)=>obj.SetActive(false),
            actionOnDestroy: (obj)=> Destroy(obj),
            collectionCheck:true,
            defaultCapacity: _defaultCapacity,
            maxSize:_maxSize
            ) ;

        _prefab.GetComponent<Cube>();  
    }

    private void Start()
    {
        InvokeRepeating(nameof(Getobject), _time, _repeate);
    }

    private void ActionOnGet(GameObject obj)
    {
        obj.transform.position= GetPosition();
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.SetActive(true);
    }

    private void Getobject()
    {
        _pool.Get();
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
}
