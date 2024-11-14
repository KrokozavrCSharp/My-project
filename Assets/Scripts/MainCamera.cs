using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    private float _speed = 0.2f;

    private void Update()
    {
        transform.RotateAround(transform.position,Vector3.up,_speed);
    }
}
