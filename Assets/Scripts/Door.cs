using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]private Animator _animator;

    private int _openTrigger = Animator.StringToHash("Open");

    public void Open()
    {
        _animator.SetTrigger(_openTrigger);
    }
}
