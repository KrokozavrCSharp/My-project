using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public event Action Enter;
    public event Action Exit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            Enter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            Exit?.Invoke();
        }
    }
}
