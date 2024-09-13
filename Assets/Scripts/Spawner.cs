using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private int _minCountBoxes = 2;
    private int _maxCountBoxes = 6;

    private void OnEnable() => _cube.Activate += CreateCubs;

    private void OnDisable() => _cube.Activate -= CreateCubs;

    public void CreateCubs(Cube cube)
    {
        int divider = 2;

        int countBoxes = UnityEngine.Random.Range(_minCountBoxes, _maxCountBoxes + 1);

        for (int i = 0; i < countBoxes; i++)
        {
            Cube newCube= Instantiate(cube, transform.position, transform.rotation);

            newCube.Init(cube.ChanceDivision/ divider);
        }
    }
}
