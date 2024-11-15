using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform[] _way;
    [SerializeField] private float _speed;

    private int _position = 0;

    private void Update()
    {
        if (transform.position == _way[_position].position)
        {
            _position=(_position+1)% _way.Length;
        }

        transform.LookAt(_way[_position]);
        transform.position=Vector3.MoveTowards(transform.position, _way[_position].position,_speed*Time.deltaTime);
    }
}