using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform[] _direction;
    [SerializeField] private float _speed;

    private int _indexDirection = 0;

    private void Update()
    {
        if (transform.position == _direction[_indexDirection].position)
        {
            _indexDirection=(_indexDirection+1)% _direction.Length;
        }

        transform.LookAt(_direction[_indexDirection]);
        transform.position=Vector3.MoveTowards(transform.position, _direction[_indexDirection].position,_speed*Time.deltaTime);
    }
}