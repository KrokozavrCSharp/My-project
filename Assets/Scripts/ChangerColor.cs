using UnityEngine;

public class ChangerColor : MonoBehaviour
{
    [SerializeField]private Cube cube;

    private void OnEnable()
    {
        cube.Touched += ChangeColor;
    }

    private void OnDisable()
    {
        cube.Touched -= ChangeColor;
    }

    private void ChangeColor(Cube cube)
    {
        if (cube.TryGetComponent(out Renderer material))
            material.material.color = UnityEngine.Random.ColorHSV();
    }
}
