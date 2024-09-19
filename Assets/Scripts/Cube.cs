using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    private Material _material;
    private bool _isChangeColor = false;
    private int _delay;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isChangeColor == false)
        {
            ChangeColor();
            _isChangeColor = true;
        }

        Destroy(gameObject, GetRandomNumber(_delay));
    }

    private void ChangeColor()
    {
        _material.color = Random.ColorHSV();
    }

    private  int GetRandomNumber(int delay)
    {
        int minNumber = 2;
        int maxNumber = 6;

        int randomNumber = Random.Range(minNumber, maxNumber);

        delay = randomNumber;

        return delay;
    }
}
