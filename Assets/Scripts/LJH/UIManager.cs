using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider slider;
    [SerializeField] Text percentText;

    public void OnChangeSlider(){
        audioSource.volume = slider.value;
        percentText.text = (slider.value * 100).ToString("0") + "%";
    }
}
