using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCube : MonoBehaviour
{
    [SerializeField] private Vector3 _movementDirection;
    
    private void Update()
    {
        transform.rotation*=Quaternion.Euler(_movementDirection);
    }
}
