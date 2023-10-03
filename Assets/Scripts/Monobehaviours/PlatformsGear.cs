using UnityEngine;
using Zenject;

public class PlatformsGear : MonoBehaviour
{
    [SerializeField]
    private Transform[] Platforms;
    
    [Inject] 
    private GameDataService GameDataService;

    private void Update()
    {
        for (int i = 0; i < Platforms.Length; i++)
        {
            Platforms[i].localPosition += Vector3.back * GameDataService.CurrentSpeed * Time.deltaTime;
            if (Platforms[i].localPosition.z <= Platforms[i].localScale.z)
            {
                Platforms[i].localPosition += Vector3.forward * Platforms[i].localScale.z * Platforms.Length;
            }
        }
    }
}


