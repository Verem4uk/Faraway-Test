using UnityEngine;
using Zenject;

public class CoinView : MonoBehaviour
{
    [SerializeField]
    private Effect Effect;

    [Inject] 
    private GameDataService DataService;
    
    private Coin Coin;

    private void Start()
    {
        Coin = new Coin(Effect);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up);
        transform.position += Vector3.back * DataService.CurrentSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Coin.PickUp();
        }
        gameObject.SetActive(false);
    }
}
