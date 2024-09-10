using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    private int _chanceDivision = 100;
    private Material _material;

    public event Action <Cube> Activate;

    public int ChanceDivision => _chanceDivision;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void OnMouseUpAsButton()
    {
        int minNumber = 0;
        int maxNumber = 100;

        int chance = UnityEngine.Random.Range(minNumber, maxNumber + 1);

        if (chance < _chanceDivision)
        {
            Activate?.Invoke(this);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Init(int chanceDivision)
    {
        int divider = 2;

        _chanceDivision = chanceDivision;
        transform.localScale /= divider;
        _material.color = UnityEngine.Random.ColorHSV();
    }
}
