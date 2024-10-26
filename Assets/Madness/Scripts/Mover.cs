using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _speed = 2;

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.position += (transform.forward * Time.deltaTime * _speed);
    }
}