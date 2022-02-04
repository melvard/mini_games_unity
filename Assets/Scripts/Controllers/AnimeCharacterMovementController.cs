using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeCharacterMovementController : MonoBehaviour
{
    public float SmoothAngleRotateTime = 0.1f;

    private float speed;
    private float velocity;


    public void SetRunSpeed(float sp)
    {
        speed = sp;
    }

    public void Run(Vector3 delta)
    {

        if (runCoroutine != null) StopCoroutine(runCoroutine);
        runCoroutine = StartCoroutine(runRoutine(delta));
    }

    public void Turn(Vector3 delta)
    {
        Vector3 direction = delta.normalized;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref velocity, SmoothAngleRotateTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
       
    }

    Coroutine runCoroutine;
    private IEnumerator runRoutine(Vector3 delta)
    {
        yield return null;
    }

    Coroutine turnCoroutine;
    private IEnumerator turnRoutine(Vector3 delta)
    {
        var turnTime = 0.5f;
        for (float i = 0; i < turnTime; i += Time.fixedTime)
        {
            var rotated = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up) * delta;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotated.normalized, transform.up), i / turnTime);
            yield return null;
        }
    }
}
