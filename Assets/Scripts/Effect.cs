using UnityEngine;
using Zenject;

public abstract class Effect : ScriptableObject
{
    [Inject]
    protected ConfigProvider ConfigProvider;
    public void Apply()
    {
        ConfigProvider.OnEffectStarted?.Invoke(this); 
    }
    public abstract void StartAction();

    public virtual void FinishAction() => ConfigProvider.OnEffectEnded?.Invoke(this);

    public abstract float GetTimeInSeconds();
}
