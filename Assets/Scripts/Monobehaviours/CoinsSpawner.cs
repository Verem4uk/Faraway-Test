using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField]
    private CoinView[] CoinPrefabs;

    [SerializeField] 
    private float SpawnFriquency = .5f;
    
    [SerializeField]
    private Transform LeftSpawnPoint;
    
    [SerializeField]
    private Transform RightSpawnPoint;
    
    [SerializeField]
    private Transform MiddleSpawnPoint;

    [Inject] 
    private DiContainer Container;
    
    [SerializeField] 
    private FlyEffect FlyEffect;
   
    private List<CoinView> CoinsPool = new List<CoinView>();

    private void Start()
    {
        StartCoroutine(CoroutineSpawner());
    }

    private void SpawnCoin()
    {
        if (TryGetObjectFromPool())
        {
            return;
        }
        
        var randomNumber = Random.Range(0, CoinPrefabs.Length);
        var newCoin = Instantiate(CoinPrefabs[randomNumber], PickUpPosition(), Quaternion.identity);
        Container.Inject(newCoin);
        CoinsPool.Add(newCoin);

        bool TryGetObjectFromPool()
        {
            if (CoinsPool.Count <= 0)
            {
                return false;
            }
            foreach (var coin in CoinsPool)
            {
                if (!coin.isActiveAndEnabled)
                {
                    coin.transform.position = PickUpPosition();
                    coin.gameObject.SetActive(true);
                    return true;
                }
            }

            return false;
        }
    }

    private Vector3 PickUpPosition()
    {
        var randomNumber = Random.Range(0, 6);
        switch (randomNumber)
        {
            case 0: return LeftSpawnPoint.position;
            case 1: return RightSpawnPoint.position;
            case 2: return MiddleSpawnPoint.position;
            case 3: return LeftSpawnPoint.position + Vector3.up * FlyEffect.HeightOfFlyCoins; 
            case 4: return RightSpawnPoint.position + Vector3.up * FlyEffect.HeightOfFlyCoins;
            case 5: return MiddleSpawnPoint.position + Vector3.up * FlyEffect.HeightOfFlyCoins;
        }
        Debug.LogError("Number is out of positions");
        return LeftSpawnPoint.position;
    }

    private IEnumerator CoroutineSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnFriquency);
            SpawnCoin();
        }
    }
}
