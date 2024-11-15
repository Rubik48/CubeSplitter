using UnityEngine;
using Random = UnityEngine.Random;

public class ChangeRandomColor : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private void OnEnable()
    {
        Renderer colorNewCube = _cubePrefab.GetComponent<Renderer>();
        
        if(colorNewCube != null)
        {
            colorNewCube.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
