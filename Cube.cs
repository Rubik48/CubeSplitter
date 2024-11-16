using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private CubeManager _cubeManager;
    
    public float SplitChance { get; private set; } = 1f;

    public event Action<Cube> Splited;
    
    private void OnMouseDown()
    {
        if (Random.value <= SplitChance)
        {
            Splited?.Invoke(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Init(float splitChance)
    {
        SplitChance = splitChance;
        
        _cubeManager.AddCube(this);
    }
}
