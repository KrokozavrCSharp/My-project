using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private float _speedMove = 0.5f;
    private float _speedRotate = 30.5f;

    public void Update()
    {
        Rotate();
        Move();
    }

    private void Move()
    {
        float direction = Input.GetAxis(Vertical);
        float distance = direction * _speedMove * Time.deltaTime;

        transform.Translate(distance * Vector3.forward);
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);

        transform.Rotate(rotation * Vector3.up * _speedRotate * Time.deltaTime);
    }
}