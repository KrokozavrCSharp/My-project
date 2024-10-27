using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Crab : MonoBehaviour
{
    private Vector3 _turn;

    private void Start()
    {
        Rotate();
    }

    public void Initialize(Vector3 turn)
    {
        _turn = turn;
    }

    private void Rotate()
    {
        transform.rotation *= Quaternion.Euler(_turn);
    }
}
