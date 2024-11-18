using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeExplosion : MonoBehaviour
{
    [SerializeField, Min(1f)] private float _explosionForce = 300f;
    [SerializeField, Min(1f)] private float _explosionRadius = 5f;

    private void OnEnable()
    {
        Rigidbody cubeRigidbody = GetComponent<Rigidbody>();
        
        if (cubeRigidbody != null)
        {
            cubeRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
