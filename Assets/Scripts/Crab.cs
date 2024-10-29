using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Crab : MonoBehaviour
{
    private Vector3 _direction;

    private void Start()
    {
        if (TryGetComponent(out Transform transform))
        {
            transform.forward = _direction;
        }
    }

    public void Initialize(Vector3 turn)
    {
        _direction = turn;
    }
}
