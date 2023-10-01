using UnityEngine;
using Zenject;

public class PlatformsGear : MonoBehaviour
{
    [SerializeField]
    private Transform[] platforms;

    [Inject] 
    private ConfigProvider ConfigProvider;
    
    private void Update()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].localPosition += Vector3.back * ConfigProvider.CurrentSpeed * Time.deltaTime;
            if (platforms[i].localPosition.z <= platforms[i].localScale.z)
            {
                platforms[i].localPosition += Vector3.forward * platforms[i].localScale.z * platforms.Length;
            }
        }
    }
}
