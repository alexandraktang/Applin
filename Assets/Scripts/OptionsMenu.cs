using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/*
   Credit to John Leonard French for the smooth logarithmic volume slider & saving and loading volume between scenes
   https://johnleonardfrench.com/the-right-way-to-make-a-volume-slider-in-unity-using-logarithmic-conversion/
*/

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; // on Unity
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Volume", 0.75f); // default is set to 75, otherwise default for float is 0
    }

    public void SetVolume (float volume) 
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20); // credit: jeonleonardfrench for log funct
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
