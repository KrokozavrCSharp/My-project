using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCube : MonoBehaviour
{
    [SerializeField] private Vector3 _movementDirection;
    // Update is called once per frame
    void Update()
    {
        transform.rotation*=Quaternion.Euler(_movementDirection);
    }
}
