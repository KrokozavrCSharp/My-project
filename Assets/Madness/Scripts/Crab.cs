using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Crab : MonoBehaviour
{
    private Vector3 _direction;

    private void Start()
    {
        Rotate();
    }

    public void Initialize(Vector3 direction)
    {
        _direction = direction;
    }

    private void Rotate()
    {
        transform.rotation *= Quaternion.Euler(_direction);
    }
}
