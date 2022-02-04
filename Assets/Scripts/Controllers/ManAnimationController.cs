using UnityEngine;


public class ManAnimationController : MonoBehaviour
{
    private Animator animator; // or can be passed as [SerializeField]

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartRunning()
    {
        animator.SetBool("Run", true);
    }

    public void Idle()
    {
        animator.SetBool("Run", false);
    }

    public void Die()
    {
        animator.SetBool("Die", true);
    }
    public void SetRunSpeed(float speed)
    {
        animator.SetFloat("RunSpeed", speed);
    }

}
