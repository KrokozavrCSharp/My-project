using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private Material _material;
    private bool _isTouch=false;

    public event Action<Cube> Destroyed;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isTouch == false && collision.collider.TryGetComponent<Platforma>(out Platforma triggerObject))
        {
            _isTouch = true;
            ChangeColor();
            StartCoroutine(Destroing());
        }
    }

    private void SetDefaultColor()
    {
        _material.color = Color.white;
    }

    private void ChangeColor()
    {
        _material.color = UnityEngine.Random.ColorHSV();
    }

    private  IEnumerator Destroing()
    {
        int minNumber = 5;
        int maxNumber = 10;

        int delay = UnityEngine.Random.Range(minNumber, maxNumber);

        var waitForSeconds = new WaitForSeconds(delay);

        yield return waitForSeconds;

        Destroyed?.Invoke(this);

        _isTouch = false;

        SetDefaultColor();
    }
}
