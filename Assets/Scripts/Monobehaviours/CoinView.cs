using UnityEngine;

public class CoinView : SceneObject
{
    [SerializeField]
    private ECoinEffectType CoinEffectType;
    
    private Coin Coin;

    private void Start()
    {
        var fabric = new CoinsFabric();
        Coin = CoinEffectType switch
        {
            ECoinEffectType.SpeedUp => fabric.GenerateSpeedUpCoin,
            ECoinEffectType.SpeedDown => fabric.GenerateSpeedDownCoin,
            ECoinEffectType.Fly => fabric.GenerateFlyCoin,
            _ => Coin
        };
    }

    private void Update()
    {
        transform.Rotate(Vector3.up);
        transform.position += Vector3.back * ConfigProvider.CurrentSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Coin.PickUp(ConfigProvider);
        }
        gameObject.SetActive(false);
    }

    private enum ECoinEffectType
    {
        SpeedUp,
        SpeedDown,
        Fly
    }
}
