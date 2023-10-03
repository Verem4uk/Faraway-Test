using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SOInstaller", menuName = "Installers/SOInstaller")]
public class SOInstaller : ScriptableObjectInstaller
{
    [SerializeField]
    private Effect[] Effects;

    public override void InstallBindings()
    {
        Container.Bind<GameDataService>().AsSingle();
        foreach (var effect in Effects)
        {
            Container.QueueForInject(effect);
        }
    }
}
