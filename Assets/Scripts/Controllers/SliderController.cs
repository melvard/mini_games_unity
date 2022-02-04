using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] Slider slider;

    private Image fillerImage;
    private void OnEnable()
    {
        fillerImage = slider.targetGraphic.GetComponent<Image>();
    }
    public void SetSliderValue(float value)
    {
        fillerImage.color = Color.HSVToRGB(0, value, 1f);
        slider.value = value;
    }
}
