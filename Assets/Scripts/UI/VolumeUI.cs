using UnityEngine;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour
{
    [Header("볼륨 조절 슬라이더")]
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _sfxSlider;

    private void Start()
    {
        _bgmSlider.onValueChanged.AddListener(AudioManager.Instance.SetBGMVolume);
        _sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SetSFXVolume);
        
        _bgmSlider.value = AudioManager.Instance.GetBGMVolume();
        _sfxSlider.value = AudioManager.Instance.GetSFXVolume();
    }
}