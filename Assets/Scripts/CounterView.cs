using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;

    [SerializeField] private Counter _counter;

    private void Update()
    {
        DisplayCountdown(_counter.Points);
    }

    private void OnEnable()
    {
        _counter.PointsChanged += DisplayCountdown;
    }

    private void OnDisable()
    {
        _counter.PointsChanged -= DisplayCountdown;
    }

    private void DisplayCountdown(int number)
    {
        _text.text = number.ToString();
    }
}
