using UnityEngine;

public class EffectPerformer : SceneObject
{
    private Effect currentEffect;
    private float effectStartTime;
    private bool isEffectActive;

    public override void Initialize(ConfigProvider configProvider)
    {
        base.Initialize(configProvider);
        configProvider.OnEffectStarted = PerformEffect;
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
            // Если текущий эффект активен, проверьте его тип
            if (currentEffect.GetType() == effect.GetType())
            {
                // Если новый эффект совпадает по типу, продлите время действия
                effectStartTime = Time.time;
                return;
            }
            // Если новый эффект отличается, завершите текущий эффект
            currentEffect.FinishAction();
        }

        currentEffect = effect;
        effect.StartAction();
        effectStartTime = Time.time;
        isEffectActive = true;
    }
}