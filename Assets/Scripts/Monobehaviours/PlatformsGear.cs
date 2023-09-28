using UnityEngine;

public class PlatformsGear : SceneObject
{
    [SerializeField]
    private Transform[] platforms;
    
    private void Update()
    {
        if (!isInitialized)
        {
            return;
        }
        
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
