using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _points;
    private float _declay = 0.5f;
    private bool _isActivateCoroutine;
    private KeyCode _leftMouseButton=KeyCode.Mouse0;
    private Coroutine _coroutine;
    
    public event Action<int> PointsChanged;
    
    public int Points => _points;

    private void Start()
    {
        int number = 0;

        _points = number;
    }

    private void Update()
    {
        if (Input.GetKey(_leftMouseButton))
        {
            Click();
        }
    }

    private IEnumerator Counting()
    {
        var wait = new WaitForSeconds(_declay);

        while (_isActivateCoroutine)
        {
            _points++;

            PointsChange?.Invoke(_points);

            yield return wait;
        }
    }

    private void Click()
    {
        if(_isActivateCoroutine==false)
        {
            _isActivateCoroutine = true;
            _coroutine=StartCoroutine(Counting());
        }
        else
        {
            _isActivateCoroutine = false;
            StopCoroutine(_coroutine);
        }
    }
}
