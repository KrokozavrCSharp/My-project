using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private GameObject _spawner;

    private float _speed = 2;

    private void Start()
    {
        Rotation();
    }

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.position += (transform.forward * Time.deltaTime * _speed);
    }

    private void Rotation()
    {
        if (_spawner.TryGetComponent(out SpawnerCrabs spawn))
        {
            transform.rotation *= Quaternion.Euler(spawn.SetDirection());
        }
    }
}