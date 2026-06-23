using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerController : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string SoundsVolume = nameof(SoundsVolume);
    private const float DecibelMultiplier = 20f;
    private const float MinVolume = 0.0001f;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _soundsSlider;

    private void Start()
    {
        SetMasterVolume(_masterSlider.value);
        SetSoundsVolume(_soundsSlider.value);
    }

    public void SetMasterVolume(float value)
    {
        SetVolume(MasterVolume, value);
    }

    public void SetSoundsVolume(float value)
    {
        SetVolume(SoundsVolume, value);
    }

    private void SetVolume(string volumeName, float value)
    {
        float volume = Mathf.Log10(Mathf.Max(value, MinVolume)) * DecibelMultiplier;
        _audioMixer.SetFloat(volumeName, volume);
    }
}