using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;
    
    private static readonly int Run = Animator.StringToHash("Run");
    private static readonly int Shoot = Animator.StringToHash("Shoot");

    public void HandleMovementAnimation(Vector3 inputVector)
    {
        playerAnim.SetBool(Run, inputVector.magnitude != 0f);
    }

    public void PlayShootAnimation()
    {
        playerAnim.SetTrigger(Shoot);
    }
}