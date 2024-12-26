using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _way;

    private int _position = 0;

    public void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position == _way[_position].position)
        {
            _position = (_position + 1) % _way.Length;
        }

        transform.LookAt(_way[_position]);
        transform.position = Vector3.MoveTowards(transform.position, _way[_position].position, _speed * Time.deltaTime);
    }
}