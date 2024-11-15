using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    private float _splitChance = 1f;
    private float _reducerChance = 2f;
    
    public float SplitChance => _splitChance;

    public event Action Splited;
    
    public void ReduceSplitChance(float splitChance)
    {
        _splitChance = splitChance / _reducerChance;
    }
    
    private void OnMouseDown()
    {
        if (Random.value <= _splitChance)
        {
            Splited?.Invoke();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
