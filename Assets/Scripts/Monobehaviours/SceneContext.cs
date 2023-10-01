using UnityEngine;

public class SceneContext : MonoBehaviour
{
    [SerializeField]
    private ConfigProvider ConfigProvider;
    
    private void Start() //entry point, initialize all the 
    {
        ConfigProvider.ResetSpeed();
        ConfigProvider.OnEffectEnded = null;
        ConfigProvider.OnEffectStarted = null;
    }
}
