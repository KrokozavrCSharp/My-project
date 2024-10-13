using UnityEngine;

public class ChangerColor : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        if (gameObject.TryGetComponent(out Renderer renderer))
            _renderer = renderer;
    }

    public void SetDefaultColor()
    {
        _renderer.material.color = Color.white;
    }

    public void ChangeColor()
    {
            _renderer.material.color = UnityEngine.Random.ColorHSV();
    }
}
