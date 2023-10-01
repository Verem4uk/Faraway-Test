using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SOInstaller", menuName = "Installers/SOInstaller")]
public class SOInstaller : ScriptableObjectInstaller
{
    [SerializeField]
    private ConfigProvider ConfigProvider;

    public override void InstallBindings()
    {
        //Container.BindInstance(ConfigProvider).AsSingle();
        Container.Bind<ConfigProvider>().AsSingle();
    }
}
