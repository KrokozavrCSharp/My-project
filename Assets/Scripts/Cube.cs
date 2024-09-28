using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private Material _material;
    private Rigidbody _rigidbody;
    private ChangerColor _changeColor;
    private bool _isTouch=false;

    public event Action<Cube> Destroyed;
    public event Action<Cube> Touched;

    public bool IsTouch=>_isTouch;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _rigidbody = GetComponent<Rigidbody>();
        _changeColor= GetComponent<ChangerColor>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isTouch == false && collision.collider.TryGetComponent(out Platforma _))
        {
            _isTouch = true;
            Touched?.Invoke(this);
            _changeColor.ChangeColor();
            StartCoroutine(Destroing());
        }
    } 

    private  IEnumerator Destroing()
    {
        int minNumber = 5;
        int maxNumber = 10;

        int delay = UnityEngine.Random.Range(minNumber, maxNumber);

        yield return new WaitForSeconds(delay);

        Destroyed?.Invoke(this);

        ResetState();
    }

    private void ResetState()
    {
        _changeColor.SetDefaultColor();

        _rigidbody.velocity = Vector3.zero;

        _isTouch = false;
    }
}
