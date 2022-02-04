using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ForbidenAreaController : MonoBehaviour
{
    public SliderController sliderController;
    public UnityAction OnTimerExpired;

    private bool isAnyColiderInArea;
    public bool IsAnyColiderInArea { get { return isAnyColiderInArea; } }

    private float timeInArea;
    public float TimeInArea { get { return timeInArea; } }

    private float maxTime;
    public float MaxTime {
        get
        {
            return maxTime;
        }
        set
        {
            maxTime = (value < 3) ? value : value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isAnyColiderInArea = true;
        sliderController.gameObject.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        //new WaitForEndOfFrame();
        timeInArea += Time.fixedDeltaTime;
        Debug.Log(timeInArea);
        if(timeInArea >= maxTime)
        {
            OnTimerExpired?.Invoke();
        }
        sliderController.SetSliderValue(timeInArea/maxTime);
    }

    private void OnTriggerExit(Collider other)
    {
        sliderController.SetSliderValue(0);
        sliderController.gameObject.SetActive(false);
        timeInArea = 0;
        isAnyColiderInArea = false;
    }

}
