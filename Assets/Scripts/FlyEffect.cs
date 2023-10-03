using UnityEngine;

[CreateAssetMenu(fileName = "FlyEffect", menuName = "Custom/FlyEffect")]
public class FlyEffect : Effect
{
    [SerializeField] 
    public float HeightOfFlyCoins = 5f;
    
    [SerializeField] 
    public float FlySeconds = 10;
    
    public override void Apply()
    {
        if (isEffectActive)
        {
            CancellationTokenSource.Cancel();
            RunEffect();
            return;
        }
        base.Apply();
    }
    
    protected override float GetTimeInSeconds() => FlySeconds;
}