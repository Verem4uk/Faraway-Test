using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SpeedEffect", menuName = "Custom/SpeedEffect")]
public class SpeedEffect : Effect
{
    [SerializeField] 
    public float DurationInSeconds = 10;
    
    [SerializeField] 
    public float SpeedMultiplier = 1.5f;

    [Inject] 
    private GameDataService DataService;
    
    public override void Apply()
    {
        var currentSpeed = DataService.CurrentSpeed;
        currentSpeed *= SpeedMultiplier;
        DataService.SetSpeed(currentSpeed);
        base.Apply();
    }

    public override void FinishEffect()
    {
        var currentSpeed = DataService.CurrentSpeed;
        currentSpeed /= SpeedMultiplier;
        DataService.SetSpeed(currentSpeed);
        base.FinishEffect();
    }
    protected override float GetTimeInSeconds() => DurationInSeconds;
}