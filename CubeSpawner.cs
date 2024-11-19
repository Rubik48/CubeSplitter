using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField, Min(1)] private int _minNumberCube = 2;
    [SerializeField, Min(1)] private int _maxNumberCube = 6;
    [SerializeField, Min(0f)] private float _scaleReduction = 0.5f;
    [SerializeField, Min(0f)] private float _offsetNewCube = 0.1f;
    [SerializeField, Min(0f)] private float _reducerChance = 2f;
    [SerializeField] private Cube[] _existingCubes;
    
    private List<Cube> _cubes = new List<Cube>();
    
    public event Action<Cube> CubeCreated;
    
    private void Start()
    {
        foreach (Cube cube in _existingCubes)
        {
            AddCube(cube);
        }
    }

    private void AddCube(Cube cube)
    {
        if (_cubes.Contains(cube) == false)
        {
            _cubes.Add(cube);
            cube.Splitted += SplitCube;
        }
    }

    private void RemoveCube(Cube cube)
    {
        if (_cubes.Contains(cube) == true)
        {
            _cubes.Remove(cube);
            cube.Splitted -= SplitCube;
        }
    }
    
    private void SplitCube(Cube cube)
    {
        int cubesForCreate = Random.Range(_minNumberCube, _maxNumberCube + 1);

        for (int i = 0; i < cubesForCreate; i++)
        {
            Vector3 randomOffset = Random.insideUnitSphere * _offsetNewCube;
            
            Cube newCube = Instantiate(cube, cube.transform.position + randomOffset,
                Quaternion.identity);
            newCube.transform.localScale = cube.transform.localScale * _scaleReduction;
            
            newCube.Init(cube.SplitChance / _reducerChance);
            
            CubeCreated?.Invoke(newCube);
            
            AddCube(newCube);
        }
        
        RemoveCube(cube);
    }
}