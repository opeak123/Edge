using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioMixer mixer;
    public AudioClip[] clips;
    public AudioSource[] sfxSources;
    public AudioSource[] bgmSources;

    [SerializeField]
    private Scrollbar m_bgmScrollBar;
    [SerializeField]
    private Scrollbar m_sfxScrollBar;

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

        // AudioClip dictionary�� AudioClip �߰�
        //AudioClip[] clips = Resources.LoadAll<AudioClip>("Audio");
        foreach (AudioClip clip in clips)
        {
            clipDict.Add(clip.name, clip);
        }
    }

    private void Start()
    {
        int currentSceneNumber = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        if(currentSceneNumber == 0)
        {
            GameObject canvasObject = GameObject.Find("Canvas");
            GameObject optionsObject = canvasObject.transform.GetChild(5).gameObject;
            GameObject videoAndSoundObject = optionsObject.transform.GetChild(2).gameObject;
            GameObject soundObject = videoAndSoundObject.transform.GetChild(2).gameObject;
            m_bgmScrollBar = soundObject.transform.GetChild(0).GetComponent<Scrollbar>();
            m_sfxScrollBar = soundObject.transform.GetChild(1).GetComponent<Scrollbar>();
        }
        else if(currentSceneNumber == 1)
        {

        }
        
        m_bgmScrollBar.onValueChanged.AddListener(SetBGMVolume);
        m_sfxScrollBar.onValueChanged.AddListener(SetSFXVolume);

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
        mixer.SetFloat("sfx", Mathf.Lerp(-50, 0, volume));
    }

    public void SetBGMVolume(float volume)
    {
        mixer.SetFloat("bgm", Mathf.Lerp(-50, 0, volume));
    }
}
