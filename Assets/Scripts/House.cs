using UnityEngine;
public class House : MonoBehaviour
{
    [SerializeField]private AlarmSystem _armSystem;
    [SerializeField]private AlarmTrigger _trigger;

    private void OnEnable()
    {
        _trigger.Enter += InformEnter;
        _trigger.Exit += InformExit;
    }

    private void InformEnter()
    {
        _armSystem.IncreaseVolume();
    }

    private void InformExit()
    {
        _armSystem.ReduceVolume();
    }
}
