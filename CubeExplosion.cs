using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody), typeof(Cube))]
public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField, Min(1f)] private float _explosionForce = 300f;
    [SerializeField, Min(1f)] private float _explosionRadius = 5f;

    private Cube _cube;
    
    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }
    
    private void OnEnable()
    {
        _cube.Destroyed += BlastAroundCubes;
        _cubeSpawner.CubeCreated += BlastSplittedCubes;
    }

    private void OnDisable()
    {
        _cube.Destroyed -= BlastAroundCubes;
        _cubeSpawner.CubeCreated -= BlastSplittedCubes;
    }

    private void BlastSplittedCubes(Cube cube)
    {
        Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();
        
        if (cubeRigidbody != null)
        {
            cubeRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private void BlastAroundCubes()
    {
        foreach (Rigidbody cube in GetExplodableObjects())
        {
            cube.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
    
    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);
        
        List<Rigidbody> cubes = new List<Rigidbody>();

        foreach (Collider hit in hits)
        {
            if(hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);
        }
        
        return cubes;
    }
}
