using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixerParameter _parameter;

    public event Action<AudioMixerParameter, float> ValueChanged;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }

    private void Start()
    {
        OnSliderValueChanged(_slider.value);
    }

    private void OnSliderValueChanged(float value)
    {
        ValueChanged?.Invoke(_parameter, value);
    }
}