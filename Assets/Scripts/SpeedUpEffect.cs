using UnityEngine;

[CreateAssetMenu(fileName = "SpeedUpEffect", menuName = "Custom/SpeedUpEffect")]
public class SpeedUpEffect : Effect
{
    public override void StartAction() => ConfigProvider.CurrentSpeed *= ConfigProvider.SpeedUpMultiplier;

    public override void FinishAction()
    {
        ConfigProvider.CurrentSpeed /= ConfigProvider.SpeedUpMultiplier;
        base.FinishAction();
    }
    public override float GetTimeInSeconds() => ConfigProvider.SpeedUpSeconds;
}