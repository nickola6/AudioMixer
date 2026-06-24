using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AudioVolumeSlider : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string SoundsVolume = nameof(SoundsVolume);

    private const float DecibelMultiplier = 20f;
    private const float MinVolume = 0.0001f;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioMixerParameter _parameter;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetVolume);
    }

    private void Start()
    {
        SetVolume(_slider.value);
    }

    private void SetVolume(float value)
    {
        float volume = Mathf.Log10(Mathf.Max(value, MinVolume)) * DecibelMultiplier;
        _audioMixer.SetFloat(GetParameterName(), volume);
    }

    private string GetParameterName()
    {
        switch (_parameter)
        {
            case AudioMixerParameter.Master:
                return MasterVolume;

            case AudioMixerParameter.Sounds:
                return SoundsVolume;

            default:
                return string.Empty;
        }
    }
}