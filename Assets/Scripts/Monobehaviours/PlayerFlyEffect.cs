using UnityEngine;
using Zenject;

public class PlayerFlyEffect : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    private Animator animator;
    private int isFlying = Animator.StringToHash("IsFlying");
    
    [Inject] 
    private ConfigProvider ConfigProvider;
    
    private void Start()
    {
        ConfigProvider.OnEffectStarted += OnFly;
        ConfigProvider.OnEffectEnded += OnFlyEnd;
        animator = GetComponent<Animator>();
    }
    
    
    private void OnFly(Effect effect)
    {
        if (effect is FlyEffect)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, ConfigProvider.HeightOfFlyCoins,
                transform.position.z);
            animator.SetBool(isFlying, true);
            playerMovement.MovePlayerTo(targetPosition);
        }
    }

    private void OnFlyEnd(Effect effect)
    {
        if (effect is FlyEffect)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, .5f, transform.position.z); 
            animator.SetBool(isFlying, false);
            playerMovement.MovePlayerTo(targetPosition);
        }
    }
}
