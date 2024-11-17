using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField, Min(1)] private int _minNumberCube = 2;
    [SerializeField, Min(1)] private int _maxNumberCube = 6;
    [SerializeField, Min(0f)] private float _scaleReduction = 0.5f;
    [SerializeField, Min(0f)] private float _offsetNewCube = 0.1f;
    [SerializeField, Min(0f)] private float _reducerChance = 2f;
    [SerializeField] private Cube[] existingCubes;
    
    private List<Cube> _cubes = new List<Cube>();
    
    private void Start()
    {
        foreach (Cube cube in existingCubes)
        {
            AddCube(cube);
        }
    }

    private void AddCube(Cube cube)
    {
        if (_cubes.Contains(cube) == false)
        {
            _cubes.Add(cube);
            cube.Splited += SplitCube;
        }
    }

    private void RemoveCube(Cube cube)
    {
        if (_cubes.Contains(cube) == true)
        {
            _cubes.Remove(cube);
            cube.Splited -= SplitCube;
        }
    }
    
    private void SplitCube(Cube cube)
    {
        int cubesForCreate = Random.Range(_minNumberCube, _maxNumberCube + 1);

        for (int i = 0; i < cubesForCreate; i++)
        {
            Vector3 randomOffset = Random.insideUnitSphere * _offsetNewCube;
            
            Cube newCube = Instantiate(_cubePrefab, cube.transform.position + randomOffset,
                Quaternion.identity);
            newCube.transform.localScale = cube.transform.localScale * _scaleReduction;
            
            newCube.Init(cube.SplitChance / _reducerChance);
            
            AddCube(newCube);
        }
        
        RemoveCube(cube);
        Destroy(cube.gameObject);
    }
}