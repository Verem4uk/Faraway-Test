using UnityEngine;
using Zenject;

public class EffectPerformer : MonoBehaviour
{
    private Effect currentEffect;
    private float effectStartTime;
    private bool isEffectActive;

    [Inject]
    private ConfigProvider ConfigProvider;

    private void Start()
    {
        ConfigProvider.OnEffectStarted += PerformEffect;
    }

    private void Update()
    {
        if (isEffectActive)
        {
            float elapsedTime = Time.time - effectStartTime;
            if (elapsedTime >= currentEffect.GetTimeInSeconds())
            {
                currentEffect.FinishAction();
                isEffectActive = false;
            }
        }
    }

    private void PerformEffect(Effect effect)
    {
        if (isEffectActive)
        {
            if (currentEffect.GetType() == effect.GetType())
            {
                // If is the same effect - reset timer
                effectStartTime = Time.time;
                return;
            }
            // If isn't the same effect - finish it
            currentEffect.FinishAction();
        }
        
        currentEffect = effect;
        effect.StartAction();
        effectStartTime = Time.time;
        isEffectActive = true;
    }
}