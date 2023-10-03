using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public Action<Effect> OnEffectStarted;
    public Action<Effect> OnEffectEnded;
    
    protected bool IsEffectActive { private set; get; }
    
    protected CancellationTokenSource CancellationTokenSource;
    protected abstract float GetTimeInSeconds();
    
    public virtual void Apply()
    {
        OnEffectStarted?.Invoke(this);
        IsEffectActive = true;
        RunEffect();
    }

    protected void RunEffect()
    {
        CancellationTokenSource = new CancellationTokenSource();
        _ = RunEffect(CancellationTokenSource.Token);
    }

    public virtual void FinishEffect()
    {
        OnEffectEnded?.Invoke(this);
        IsEffectActive = false;
    }

    private async Task RunEffect(CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(GetTimeInSeconds()), cancellationToken);
        if (!cancellationToken.IsCancellationRequested)
        {
            FinishEffect();
        }
    }
}
