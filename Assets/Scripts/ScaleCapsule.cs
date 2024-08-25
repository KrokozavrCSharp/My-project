using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCapsule : MonoBehaviour
{
    [SerializeField] private float _speed;

    // Update is called once per frame
    void Update()
    {
        
        transform.localScale+=new Vector3(_speed,_speed,_speed)*Time.deltaTime;
    }
}
