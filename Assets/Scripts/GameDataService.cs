using System;
using UnityEngine;

public class GameDataService
{
    public float CurrentSpeed { get; private set; } = 10;
    
    public event Action<float> OnSpeedChanged;

    public void SetSpeed(float newSpeed)
    {
        CurrentSpeed = newSpeed;
        Debug.Log("New speed is "+newSpeed);
        OnSpeedChanged?.Invoke(newSpeed);
    }
}
