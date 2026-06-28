using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    private const float DecibelMultiplier = 20f;
    private const float MinVolume = 0.0001f;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private VolumeSlider[] _volumeSliders;

    private void OnEnable()
    {
        foreach (VolumeSlider slider in _volumeSliders)
            slider.ValueChanged += SetVolume;
    }

    private void OnDisable()
    {
        foreach (VolumeSlider slider in _volumeSliders)
            slider.ValueChanged -= SetVolume;
    }

    private void SetVolume(AudioMixerParameter parameter, float value)
    {
        float volume = Mathf.Log10(Mathf.Max(value, MinVolume)) * DecibelMultiplier;
        _audioMixer.SetFloat(parameter.ToString(), volume);
    }
}