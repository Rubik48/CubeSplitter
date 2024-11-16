using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class ChangerRandomColor : MonoBehaviour
{
    private void OnEnable()
    {
        Renderer renderer = GetComponent<Renderer>();
        
        if(renderer != null)
        {
            renderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
