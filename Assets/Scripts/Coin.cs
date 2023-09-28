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
