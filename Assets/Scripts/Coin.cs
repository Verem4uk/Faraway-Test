public class Coin
{
    private Effect Effect;
    public Coin(Effect effect) => Effect = effect;
    public void PickUp() => Effect.Apply();
}
