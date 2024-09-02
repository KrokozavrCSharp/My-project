using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;

    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.PointsChange += DisplayCountdown;
    }

    private void OnDisable()
    {
        _counter.PointsChange -= DisplayCountdown;
    }

    private void DisplayCountdown(int number)
    {
        float points = number;
        _text.text = points.ToString();
    }
}
    
