using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioMixer mixer;

    public AudioSource[] sfxSources;
    public AudioSource[] bgmSources;

    public Dictionary<string, AudioClip> clipDict = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        // AudioClip dictionary�� ��� AudioClip�� �߰�
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Audio");
        foreach (AudioClip clip in clips)
        {
            clipDict.Add(clip.name, clip);
        }
    }

    public void PlaySFX(string name, float volume)
    {
        // ����ִ� AudioSource�� ã�Ƽ� SFX�� ���
        foreach (AudioSource source in sfxSources)
        {
            if (!source.isPlaying)
            {
                source.clip = clipDict[name];
                source.volume = volume;
                source.Play();
                return;
            }
        }
    }

    public void PlayBGM(string name, float volume)
    {
        //��� BGM AudioSource�� ���� ���õ� BGM�� ���
        foreach (AudioSource source in bgmSources)
        {
            source.Stop();
        }

        // ���õ� BGM ���
        foreach (AudioSource source in bgmSources)
        {
            if (source.clip == null || source.clip.name != name)
            {
                source.clip = clipDict[name];
                source.volume = volume;
                source.loop = true;
                source.Play();
                return;
            }
        }
    }

    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("SFXVolume", volume);
    }

    public void SetBGMVolume(float volume)
    {
        mixer.SetFloat("BGMVolume", volume);
    }
}
