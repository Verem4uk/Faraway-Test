using UnityEngine;

public class SceneContext : MonoBehaviour
{
    [SerializeField]
    private ConfigProvider ConfigProvider;

    [SerializeField] 
    private SceneObject[] ObjectsToInitialize;
    
    private void Start() //entry point
    {
        ConfigProvider.CurrentSpeed = ConfigProvider.StartSpeed;
        for (int i = 0; i < ObjectsToInitialize.Length; i++)
        {
            ObjectsToInitialize[i].Initialize(ConfigProvider);
        }
    }
}
