using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForbidenAreaManager : MonoBehaviour
{
    public ForbidenAreaController forbidenAreaController;

    public float MaximumTimeAllowed;

    private void Start()
    {
        forbidenAreaController.MaxTime = MaximumTimeAllowed;
        forbidenAreaController.OnTimerExpired += Die;
    }

    private void Die()
    {
        AnimeGameManager.Instance.KillCharacter();
    }
}
