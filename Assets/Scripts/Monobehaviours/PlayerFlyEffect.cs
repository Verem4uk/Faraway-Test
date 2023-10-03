using UnityEngine;

public class PlayerFlyEffect : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private Animator animator;
    private int isFlying = Animator.StringToHash("IsFlying");
    
    [SerializeField] 
    private FlyEffect flyEffect;
    
    private void Start()
    {
        flyEffect.OnEffectStarted += OnFly;
        flyEffect.OnEffectEnded += OnFlyEnd;
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnFly(Effect effect)
    {
        Vector3 targetPosition = new Vector3(transform.position.x, flyEffect.HeightOfFlyCoins,
            transform.position.z);
        playerMovement.MovePlayerTo(targetPosition);
        animator.SetBool(isFlying, true);
    }

    private void OnFlyEnd(Effect effect)
    {
        Vector3 targetPosition = new Vector3(transform.position.x, .5f, transform.position.z);
        playerMovement.MovePlayerTo(targetPosition);
        animator.SetBool(isFlying, false);
    }
}
