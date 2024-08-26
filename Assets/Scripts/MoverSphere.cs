using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSphere : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        transform.position += (transform.forward * Time.deltaTime *  _speed);
    }
}
