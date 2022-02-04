using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private ManAnimationController manAnimationController;
    [SerializeField] private ManMovementController manMovementController;
    [SerializeField] private GameObject directionArrow;

    void Start()
    {
        directionArrow.SetActive(false);
        GameManager.Instance.TouchManager.AddOnDragListener((Vector2 deltaPositon) => StartMoving(deltaPositon));
        GameManager.Instance.TouchManager.AddOnEndDragListener(() => EndMovement());

    }

    public void StartMoving(Vector2 deltaPos)
    {
        if( deltaPos.magnitude > 5)
        {
            var speed = 1 + deltaPos.magnitude / 500;
            EnableDirectionArrowAndSetSpeed(speed);
            manMovementController.TurnToPointer(deltaPos);
            manMovementController.Run(deltaPos);
            manMovementController.SetRunSpeed(speed);
            manAnimationController.StartRunning();
            manAnimationController.SetRunSpeed(speed);
        }
    }

    public void EndMovement()
    {
        manAnimationController.Idle();
        manMovementController.StopRuning();
        DisableDirectionArrow();
    }

    private void EnableDirectionArrowAndSetSpeed(float speed)
    {
        directionArrow.SetActive(true);
        directionArrow.transform.localScale = new Vector3(directionArrow.transform.localScale.x, directionArrow.transform.localScale.y, speed);
    }

    private void DisableDirectionArrow()
    {
        directionArrow.SetActive(false);
        directionArrow.transform.localScale = Vector3.one;

    }
}
