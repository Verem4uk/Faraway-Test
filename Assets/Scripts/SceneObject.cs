using UnityEngine;

public class SceneObject : MonoBehaviour
{
    protected ConfigProvider ConfigProvider;
    protected bool isInitialized;
    
    public virtual void Initialize(ConfigProvider configProvider)
    {
        ConfigProvider = configProvider;
        isInitialized = true;
    }
}
