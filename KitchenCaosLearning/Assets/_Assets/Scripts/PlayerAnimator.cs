using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator; // Serialize this and put the animator is valid

    private const string IS_WALKING = "IsWalking";

    [SerializeField] private Player player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }


}
