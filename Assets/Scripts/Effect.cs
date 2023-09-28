public abstract class Effect
{
    protected ConfigProvider ConfigProvider;
    public void Apply(ConfigProvider configProvider)
    {
        ConfigProvider = configProvider;
        configProvider.OnEffectStarted?.Invoke(this); 
    }
    public abstract void StartAction();

    public virtual void FinishAction() => ConfigProvider.OnEffectEnded?.Invoke(this);

    public abstract float GetTimeInSeconds();
}
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

public class FlyEffect : Effect
{
    public override void StartAction() {}
    public override float GetTimeInSeconds() => ConfigProvider.FlySeconds;
}