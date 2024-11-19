using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    public event Action<Cube> Splitted;
    public event Action Destroyed;
    
    public float SplitChance { get; private set; } = 1f;
    
    private void OnMouseDown()
    {
        if (Random.value <= SplitChance)
        {
            Splitted?.Invoke(this);
        }
        else
        {
            Destroyed?.Invoke();
        }

        Destroy(gameObject);
    }

    public void Init(float splitChance)
    {
        SplitChance = splitChance;
    }
}
