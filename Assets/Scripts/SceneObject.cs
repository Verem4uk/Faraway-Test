using UnityEngine;

public class SceneObject : MonoBehaviour
{
    //base class for all Monobehaviours which is must be initialized by Scene Context
    protected ConfigProvider ConfigProvider;
    protected bool isInitialized;
    
    public virtual void Initialize(ConfigProvider configProvider)
    {
        ConfigProvider = configProvider;
        isInitialized = true;
    }
}
