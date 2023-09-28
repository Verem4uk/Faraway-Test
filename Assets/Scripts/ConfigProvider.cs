using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ConfigProvider", menuName = "Custom/ConfigProvider")]
public class ConfigProvider : ScriptableObject
{
    [SerializeField] 
    public float CurrentSpeed = 10.0f;
    
    [SerializeField] 
    public float StartSpeed = 10.0f;
    
    [SerializeField] 
    public float SpawnFriquency = .5f;
    
    [SerializeField] 
    public float HeightOfFlyCoins = 5f;

    [SerializeField] 
    public float SpeedUpSeconds = 10;
    
    [SerializeField] 
    public float SpeedUpMultiplier = 1.5f;
    
    [SerializeField] 
    public float SpeedDownSeconds = 10;
    
    [SerializeField] 
    public float SpeedDownMultiplier = .5f;
    
    [SerializeField] 
    public float FlySeconds = 10;

    public Action<Effect> OnEffectStarted;
}