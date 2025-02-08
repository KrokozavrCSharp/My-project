using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioAlarm;

    private float _volumeMax = 1f;
    private float _volumeMin = 0f;
    private float _nextStep = 0.5f;
    private float _delay = 0.1f;

    private Coroutine _volumeChange;

    public void IncreaseVolume()
    {
        _audioAlarm.Play();
        StartVolumeChange(_volumeMax);
    }

    public void ReduceVolume()
    {
        StartVolumeChange(_volumeMin);
    }

    private void StartVolumeChange(float targetVolume)
    {
        if (_volumeChange != null)
        {
            StopCoroutine(_volumeChange);
        }

        _volumeChange = StartCoroutine(ChangeVolume(targetVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (Mathf.Approximately(_audioAlarm.volume, targetVolume) == false)
        {
            _audioAlarm.volume = Mathf.MoveTowards(_audioAlarm.volume, targetVolume, _nextStep * Time.deltaTime);

            yield return new WaitForSeconds(_delay);
        }

        if (_audioAlarm.isPlaying && _audioAlarm.volume <= 0)
        {
            _audioAlarm.Stop();
        }
    }
}
