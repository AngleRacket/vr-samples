using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class SliderMusicVolume : MonoBehaviour
{
    public Slider mainSlider;
    public AudioSource audioSource;

    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        Debug.Log(mainSlider.value);
        audioSource.volume = mainSlider.value;
    }
}