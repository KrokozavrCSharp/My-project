using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _points;

    private float _declay = 0.5f;

    private bool _isMouseClick;

    public int Points => _points;

    public event Action<int> PointsChange;

    private void Start()
    {
        int number = 0;

        _points = number;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Click();
        }
    }

    private IEnumerator Counting()
    {
        var wait = new WaitForSeconds(_declay);

        while (_isMouseClick)
        {
            _points++;

            PointsChange?.Invoke(_points);

            yield return wait;
        }
    }

    private void Click()
    {
        if(_isMouseClick==false)
        {
            _isMouseClick = true;
            StartCoroutine(Counting());
        }
        else
        {
            _isMouseClick = false;
            StopCoroutine(Counting());
        }
    }
}
