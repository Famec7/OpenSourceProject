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

        // SFX Ŭ���� ��ųʸ��� �߰�
        sfxDictionary = new Dictionary<string, AudioClip>();
        foreach (var clip in sfxClips)
        {
            sfxDictionary[clip.name] = clip;
        }

        // �ʱ� BGM Ŭ�� ���� �� ���
        if (bgmClip != null)
        {
            PlayBGM();
        }
    }

    // BGM ���
    public void PlayBGM()
    {
        bgmSource.clip = bgmClip;
        bgmSource.loop = true; // �ݺ� ��� ����
        bgmSource.Play();
    }

    // SFX ���
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

    // BGM ���� ����
    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
    }

    // SFX ���� ����
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
}
