using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSphere : MonoBehaviour
{
    [SerializeField] private float _speed;
    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.forward * Time.deltaTime *  _speed);
    }
}
