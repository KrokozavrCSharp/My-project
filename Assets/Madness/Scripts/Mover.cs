using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private int _speed;

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        int speed = 2;

        _speed =speed;

        gameObject.transform.position+=(transform.forward* Time.deltaTime*speed);
    }
}
