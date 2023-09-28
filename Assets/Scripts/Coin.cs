public class Coin
{
    private Effect Effect;
    public Coin(Effect effect) => Effect = effect;
    public void PickUp(ConfigProvider configProvider) => Effect.Apply(configProvider);
}

public class CoinsFabric
{ 
    public Coin GenerateSpeedUpCoin => new Coin(new SpeedUpEffect());
    public Coin GenerateSpeedDownCoin => new Coin(new SpeedDownEffect());
    public Coin GenerateFlyCoin => new Coin(new FlyEffect());
}

public abstract class Effect
{
    protected ConfigProvider ConfigProvider;
    public void Apply(ConfigProvider configProvider)
    {
        ConfigProvider = configProvider;
        configProvider.OnEffectStarted?.Invoke(this); 
    }
    public abstract void StartAction();
    public abstract void FinishAction();
    public abstract float GetTimeInSeconds();
}

public abstract class SpeedEffect : Effect
{
    public override void FinishAction() => ConfigProvider.CurrentSpeed = ConfigProvider.StartSpeed;
    public abstract override float GetTimeInSeconds();
}

public class SpeedUpEffect : SpeedEffect
{
    public override void StartAction() => ConfigProvider.CurrentSpeed *= ConfigProvider.SpeedUpMultiplier;
    public override float GetTimeInSeconds() => ConfigProvider.SpeedUpSeconds;
}

public class SpeedDownEffect : SpeedEffect
{
    public override void StartAction() => ConfigProvider.CurrentSpeed *= ConfigProvider.SpeedDownMultiplier;
    public override float GetTimeInSeconds() => ConfigProvider.SpeedDownSeconds;
}

public class FlyEffect : Effect
{
    public override void StartAction()
    {
        
    }
    
    public override void FinishAction()
    {
        //ConfigProvider.Speed = StartSpeed;
    }

    public override float GetTimeInSeconds() => ConfigProvider.FlySeconds;
}
