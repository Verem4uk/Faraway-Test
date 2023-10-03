using UnityEngine;

public class PlayerFlyEffect : MonoBehaviour
{
    private PlayerMovement PlayerMovement;
    private Animator Animator;
    private int IsFlying = Animator.StringToHash("IsFlying");
    
    [SerializeField] 
    private FlyEffect FlyEffect;
    
    private void Start()
    {
        FlyEffect.OnEffectStarted += OnFly;
        FlyEffect.OnEffectEnded += OnFlyEnd;
        Animator = GetComponent<Animator>();
        PlayerMovement = GetComponent<PlayerMovement>();
    }

    private void OnFly(Effect effect)
    {
        Vector3 targetPosition = new Vector3(transform.position.x, FlyEffect.HeightOfFlyCoins, transform.position.z);
        PlayerMovement.MovePlayerTo(targetPosition);
        Animator.SetBool(IsFlying, true);
    }

    private void OnFlyEnd(Effect effect)
    {
        Vector3 targetPosition = new Vector3(transform.position.x, .5f, transform.position.z);
        PlayerMovement.MovePlayerTo(targetPosition);
        Animator.SetBool(IsFlying, false);
    }

    private void OnDisable()
    {
        FlyEffect.OnEffectStarted -= OnFly;
        FlyEffect.OnEffectEnded -= OnFlyEnd;
    }
}
