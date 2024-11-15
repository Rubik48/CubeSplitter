using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField, Min(1f)] private float _explosionForce = 300f;
    [SerializeField, Min(1f)] private float _explosionRadius = 5f;

    private void OnEnable()
    {
        Rigidbody cubeRigidbody = _cubePrefab.GetComponent<Rigidbody>();
        
        if (cubeRigidbody != null)
        {
            cubeRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
