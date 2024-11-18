using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    public event Action<Cube> Splited;
    
    public float SplitChance { get; private set; } = 1f;
    
    private void OnMouseDown()
    {
        if (Random.value <= SplitChance)
        {
            Splited?.Invoke(this);
        }
        
        Destroy(gameObject);
    }

    public void Init(float splitChance)
    {
        SplitChance = splitChance;
    }
}
