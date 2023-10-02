using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SOInstaller", menuName = "Installers/SOInstaller")]
public class SOInstaller : ScriptableObjectInstaller
{
    [SerializeField]
    private ConfigProvider ConfigProvider;
    
    [SerializeField]
    private Effect[] Effects;

    public override void InstallBindings()
    {
        Container.BindInstance(ConfigProvider).IfNotBound();
        Container.QueueForInject(ConfigProvider);
        Initialize();
    }

    private void Initialize()
    {
        ConfigProvider.Reset();
        foreach (var effect in Effects)
        {
            Container.Inject(effect);
        }
    }
}
