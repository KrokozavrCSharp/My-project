using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;

    private bool _isOpened = false;
    private bool _hasOpened = false;

    private void Update()
    {
        if (_isOpened)
            return;

        if (_hasOpened && Input.GetKeyDown(KeyCode.E))
        {
            _door.Open();
            _isOpened = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DoorOpener>())
            _hasOpened = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<DoorOpener>())
            _hasOpened = false;
    }
}