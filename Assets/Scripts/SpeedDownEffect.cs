using UnityEngine;

[CreateAssetMenu(fileName = "SpeedDownEffect", menuName = "Custom/SpeedDownEffect")]
public class SpeedDownEffect : Effect
{
    public override void StartAction() => ConfigProvider.CurrentSpeed *= ConfigProvider.SpeedDownMultiplier;
    public override void FinishAction()
    {
        ConfigProvider.CurrentSpeed /= ConfigProvider.SpeedDownMultiplier;
        base.FinishAction();
    }
    public override float GetTimeInSeconds() => ConfigProvider.SpeedDownSeconds;
}