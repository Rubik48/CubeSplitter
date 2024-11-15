using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField, Min(1)] private int _minNumberCube = 2;
    [SerializeField, Min(1)] private int _maxNumberCube = 6;
    [SerializeField, Min(0f)] private float _scaleReduction = 0.5f;
    [SerializeField, Min(0f)] private float _offsetNewCube = 0.1f;

    private void OnEnable()
    {
        _cubePrefab.Splited += SplitCube;
    }

    private void OnDisable()
    {
        _cubePrefab.Splited -= SplitCube;
    }

    private void SplitCube()
    {
        int cubesForCreate = Random.Range(_minNumberCube, _maxNumberCube + 1);

        for (int i = 0; i < cubesForCreate; i++)
        {
            Vector3 randomOffset = Random.insideUnitSphere * _offsetNewCube;
            
            Cube newCube = Instantiate(_cubePrefab, transform.position + randomOffset,
                Quaternion.identity);
            newCube.transform.localScale = transform.localScale * _scaleReduction;
            
            newCube.ReduceSplitChance(_cubePrefab.SplitChance);
        }
        
        Destroy(gameObject);
    }
}