using System.Collections;
using UnityEngine;

public class ManMovementController : MonoBehaviour
{
    private float runSpeed;

    private Coroutine runRoutine;
    public void Run(Vector2 deltaPos)
    {
        if (runRoutine != null) StopCoroutine(runRoutine);
        runRoutine = StartCoroutine(RunRoutine(deltaPos));
    }

    Coroutine turnRoutine;
    public void TurnToPointer(Vector2 deltaPos)
    {
        if (turnRoutine != null)StopCoroutine(turnRoutine);
        turnRoutine = StartCoroutine(TurnToPointerRoutine(deltaPos));
    }

    public void StopRuning()
    {
        if (runRoutine != null) StopCoroutine(runRoutine);
    }

    public void SetRunSpeed(float speed)
    {
        runSpeed = speed;
    }

    private IEnumerator RunRoutine(Vector2 deltaPos)
    {
        while (true)
        {
            if (deltaPos.magnitude < 5)
            {
                break;
            }
            var movement = new Vector3(deltaPos.x, 0, deltaPos.y);

            transform.Translate(transform.forward * runSpeed * Time.fixedDeltaTime, Space.World);
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator TurnToPointerRoutine(Vector2 deltaPos)
    {
        var time = 0.1f;
        for (float i = 0; i < time; i += Time.fixedDeltaTime)
        {
            var movement = new Vector3(deltaPos.x, 0, deltaPos.y);
            Vector3 movementRotated = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up) * movement;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementRotated.normalized), i / time);
            yield return new WaitForFixedUpdate();
        }
    }
}
