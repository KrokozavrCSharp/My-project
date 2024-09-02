using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _points;
    private float _declay = 0.5f;
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
        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

    private IEnumerator Counting()
    {
        var wait = new WaitForSeconds(_declay);

        while (true)
        {
            _points++;

            PointsChanged?.Invoke(_points);

            yield return wait;
        }
    }

    private void Click()
    {
        if (_coroutine==null)
        {
            _coroutine = StartCoroutine(Counting());
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}
