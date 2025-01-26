using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioAlarm;

    private float volumeMax = 40f;
    private float volumeMin = 0f;
    private float nextStep = 0.1f;

    private bool _isEnter = false;

    private void Awake()
    {
        _audioAlarm.volume = 0;
    }

    private void Update()
    {
        if (_isEnter)
        {
            _audioAlarm.volume = Mathf.MoveTowards(_audioAlarm.volume, volumeMax, nextStep*Time.deltaTime);
            _audioAlarm.PlayOneShot(_audioAlarm.clip, _audioAlarm.volume);
        }
        else if(_isEnter==false && _audioAlarm.volume > 0)
        {
            _audioAlarm.volume = Mathf.MoveTowards(_audioAlarm.volume, volumeMin, nextStep * Time.deltaTime);
            _audioAlarm.PlayOneShot(_audioAlarm.clip, _audioAlarm.volume);
        }
        else
        {
            _audioAlarm.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>())
        {
            _isEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>())
        {
            _isEnter = false;
        }
    }
}
