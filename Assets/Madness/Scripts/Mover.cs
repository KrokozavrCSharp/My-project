using UnityEngine;

public class Mover : MonoBehaviour
{
    private int _speed=2;

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        gameObject.transform.position+=(transform.forward* Time.deltaTime*_speed);
    }
}