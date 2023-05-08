using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer audioMixer;
    public string mixerVolumeParameter = "MasterVolume";

    void Start()
    {
        // Load the saved volume from PlayerPrefs
        float savedVolume = PlayerPrefs.GetFloat("SavedVolume", 1f);
        SetVolume(savedVolume);

        // Set the volume slider to the saved volume
        volumeSlider.value = savedVolume;
    }

    public void SetVolume(float volume)
    {
        // Clamp the volume between 0.0001f and 1f
        volume = Mathf.Clamp(volume, 0.0001f, 1f);

        // Set the volume in the AudioMixer
        audioMixer.SetFloat(mixerVolumeParameter, Mathf.Log10(volume) * 20);

        // Save the volume to PlayerPrefs
        PlayerPrefs.SetFloat("SavedVolume", volume);
    }

    public void OnVolumeSliderChanged(float volume)
    {
        SetVolume(volume);
    }
}
