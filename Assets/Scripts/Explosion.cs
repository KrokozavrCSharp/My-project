using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    private Spawner _spawner;

    private void Awake()
    {
        _spawner= GetComponent<Spawner>();
    }

    private void OnEnable()
    {
        _spawner.CreateNewCubs += Explode;
    }

    private void OnDisable()
    {
        _spawner.CreateNewCubs -= Explode;
    }

    private void Explode(List<Cube> cubes)
    {
        foreach (Cube explodablecube in cubes)
        {
            explodablecube.GetComponent<Rigidbody>().AddExplosionForce(_force, transform.position, _radius);
        }
    }
}
