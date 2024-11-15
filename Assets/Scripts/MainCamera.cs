using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private float _speed = 0.2f;

    private void Update()
    {
        transform.RotateAround(transform.position,Vector3.up,_speed);
    }
}
