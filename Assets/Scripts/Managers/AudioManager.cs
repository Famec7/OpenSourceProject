using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("BGM Clip")]
    [SerializeField] private AudioClip bgmClip;

    [Header("SFX Clips")]
    [SerializeField] private List<AudioClip> sfxClips;

    private Dictionary<string, AudioClip> sfxDictionary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // SFX 클립을 딕셔너리에 추가
        sfxDictionary = new Dictionary<string, AudioClip>();
        foreach (var clip in sfxClips)
        {
            sfxDictionary[clip.name] = clip;
        }

        // 초기 BGM 클립 설정 및 재생
        if (bgmClip != null)
        {
            PlayBGM();
        }
    }

    // BGM 재생
    public void PlayBGM()
    {
        bgmSource.clip = bgmClip;
        bgmSource.loop = true; // 반복 재생 설정
        bgmSource.Play();
    }

    // SFX 재생
    public void PlaySFX(string clipName)
    {
        if (sfxDictionary.TryGetValue(clipName, out var clip))
        {
            sfxSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning($"SFX clip {clipName} is not found!");
        }
    }

    // BGM 볼륨 설정
    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
    }

    // SFX 볼륨 설정
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
    
    // BGM 볼륨 반환
    public float GetBGMVolume()
    {
        audioMixer.GetFloat("BGMVolume", out var volume);
        return Mathf.Pow(10, volume / 20);
    }
    
    // SFX 볼륨 반환
    public float GetSFXVolume()
    {
        audioMixer.GetFloat("SFXVolume", out var volume);
        return Mathf.Pow(10, volume / 20);
    }
}
