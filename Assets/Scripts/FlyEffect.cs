using UnityEngine;

[CreateAssetMenu(fileName = "FlyEffect", menuName = "Custom/FlyEffect")]
public class FlyEffect : Effect
{
    public override void StartAction() {}
    public override float GetTimeInSeconds() => ConfigProvider.FlySeconds;
}