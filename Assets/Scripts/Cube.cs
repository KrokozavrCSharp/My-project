using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    private int _chanceDivision = 100;
    private Material _material;
    private Rigidbody _rigidbody;

    public int ChanceDivision => _chanceDivision;

    private void Awake()
    {
        _rigidbody= GetComponent<Rigidbody>();
        _material= GetComponent<Renderer>().material;
    }

    public void Init()
    {
        int divider = 2;

        _chanceDivision/=divider;
        transform.localScale /=divider;
        _material.color = Random.ColorHSV();
    }
}
