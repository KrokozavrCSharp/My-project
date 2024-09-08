using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private Cube _cube;


    private int _minCountBoxes = 2;
    private int _maxCountBoxes = 6;

    private void OnEnable()
    {
        _explosion.Destroyed += CreateCube;
    }

    private void OnDisable()
    {
        _explosion.Destroyed -= CreateCube;
    }

    private void CreateCube(Cube cube)
    {
        int countBoxes = Random.Range(_minCountBoxes, _maxCountBoxes + 1);

        for (int i = 0; i < countBoxes; i++)
        {
            Cube newCube;

            newCube = Instantiate(cube, transform.position, transform.rotation);
            newCube.Init();
        }
    }
}
