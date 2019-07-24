using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class SliderMusicVolume : MonoBehaviour
{
    public AudioSource audioSource;

    private Slider slider;

    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        slider = this.gameObject.GetComponent<Slider>();
        if (slider == null) return;
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        if (audioSource == null) return;
        Debug.Log(slider.value);
        audioSource.volume = slider.value;
    }
}