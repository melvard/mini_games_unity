using UnityEngine;

public class AnimePlayerManager : MonoBehaviour
{
    [SerializeField] private ManAnimationController manAnimationController;
    [SerializeField] private AnimeCharacterMovementController animeCharacterMovementController;
    [SerializeField] private float speed;

    private void Start()
    {
        AnimeGameManager.Instance.animeTouchManager.SubscribeToOnDrag((Vector3 delta) => StartRunning(delta));
        AnimeGameManager.Instance.animeTouchManager.SubscribeToOnEndDrag(() => StopRunning());

    }

    private void StartRunning(Vector3 delta)
    {
        animeCharacterMovementController.Turn(delta);
        animeCharacterMovementController.SetRunSpeed(speed);
        manAnimationController.SetRunSpeed(speed);
        manAnimationController.StartRunning();

    }
    private void StopRunning()
    {
        manAnimationController.Idle();
    }

    public void Kill()
    {
        manAnimationController.Die();

    }

}
