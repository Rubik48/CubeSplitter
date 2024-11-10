using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField, Min(1)] private int _minNumberCube = 2;
    [SerializeField, Min(1)] private int _maxNumberCube = 6;
    [SerializeField, Min(1f)] private float _explosionForce = 300f;
    [SerializeField, Min(1f)] private float _explosionRadius = 5f;
    [SerializeField, Min(0f)] private float _scaleReduction = 0.5f;
    [SerializeField, Min(0f)] private float _splitChance = 0.5f;
    [SerializeField, Min(0f)] private float _offsetNewCube = 0.1f;
    
    private float _minScale = 0.1f;
    
    private void OnMouseDown()
    {
        if (transform.localScale.x <= _minScale)
        {
            Destroy(gameObject);
            return;
        }

        if (Random.value <= _splitChance)
        {
            SplitCube();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SplitCube()
    {
        int cubesForCreate = Random.Range(_minNumberCube, _maxNumberCube);

        for (int i = 0; i < cubesForCreate; i++)
        {
            Vector3 randomOffset = Random.insideUnitSphere * _offsetNewCube;
            
            GameObject newCube = Instantiate(_cubePrefab, transform.position + randomOffset,
                Quaternion.identity);
            newCube.transform.localScale = transform.localScale * _scaleReduction;
            
            Renderer colorNewCube = newCube.GetComponent<Renderer>();
            if (colorNewCube != null)
            {
                colorNewCube.material.color = new Color(Random.value, Random.value, Random.value);
            }
            
            Rigidbody cubeRigidbody = newCube.GetComponent<Rigidbody>();
            if (cubeRigidbody != null)
            {
                cubeRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
        
        Destroy(gameObject);
    }
}
