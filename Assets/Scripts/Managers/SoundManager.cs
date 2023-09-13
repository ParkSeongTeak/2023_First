using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    /// <summary> 캐싱을 이용하면 효율적 </summary>
    AudioSource[] _audioSources = new AudioSource[(int)Define.Sounds.MaxCount];
    public AudioSource[] AudioSources { get { return _audioSources; } }

    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    public void init()
    {
        GameObject root = GameObject.Find("@Sound");

        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
            UnityEngine.Object.DontDestroyOnLoad(root);
            string[] soundNames = System.Enum.GetNames(typeof(Define.Sounds));
            for (int i = 0; i < soundNames.Length - 1; i++)
            {
                GameObject go = new GameObject { name = soundNames[i] };
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }

            _audioSources[(int)Define.Sounds.BGM].loop = true;
            SetVolume(Define.Sounds.BGM, GameManager.InGameDataManager.BGMVolume);
            SetVolume(Define.Sounds.SFX, GameManager.InGameDataManager.SFXVolume);
            
        }
       

    }

    /// <summary>
    /// SFX용 PlayOneShot으로 구현 
    /// </summary>
    /// <param name="SFXSound"> Define.SFX Enum 에서 가져오기를 바람 </param>
    /// <param name="volume"></param>

    public void Play(Define.SFX SFXSound)
    {
        string path = Enum.GetName(typeof(Define.SFX), SFXSound);
        AudioClip audioClip = GetOrAddAudioClip(path, Define.Sounds.SFX);
        Play(audioClip, Define.Sounds.SFX);
    }




    public void SetVolume(Define.Sounds type, float volume)
    {
        _audioSources[(int)type].volume = volume;
    }
    public float GetVolume(Define.Sounds type)
    {
        return _audioSources[(int)type].volume;
    }

    public float GetVolumeBGM(Define.BGM bgmType)
    {
        return _audioSources[(int)bgmType].volume;
    }



    /// <summary>
    /// BGM용 Play로 구현
    /// </summary>
    /// <param name="BGMSound">Define.BGM Enum 에서 가져오기를 바람 </param>
    /// <param name="volume"></param>
    public void Play(Define.BGM BGMSound)
    {
        string path = Enum.GetName(typeof(Define.BGM), BGMSound);
        AudioClip audioClip = GetOrAddAudioClip(path, Define.Sounds.BGM);
        Play(audioClip, Define.Sounds.BGM);
    }

    public void Play(AudioClip audioClip, Define.Sounds type = Define.Sounds.SFX)
    {
        if (audioClip == null)
            return;

        if (type == Define.Sounds.BGM)
        {
            AudioSource audioSource = _audioSources[(int)Define.Sounds.BGM];
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            AudioSource audioSource = _audioSources[(int)Define.Sounds.SFX];
            audioSource.PlayOneShot(audioClip);
        }
    }

    AudioClip GetOrAddAudioClip(string path, Define.Sounds type = Define.Sounds.SFX)
    {
        if (type == Define.Sounds.SFX)
        {
            if (path.Contains("Sounds/SFX/") == false)
                path = $"Sounds/SFX/{path}";
        }
        else
        {
            if (path.Contains("Sounds/BGM") == false)
                path = $"Sounds/BGM/{path}";
        }

        AudioClip audioClip = null;

        if (type == Define.Sounds.BGM)
        {
            audioClip = GameManager.ResourceManager.Load<AudioClip>(path);
        }
        else
        {
            if (_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = GameManager.ResourceManager.Load<AudioClip>(path);
                _audioClips.Add(path, audioClip);
            }
        }

        if (audioClip == null)
            Debug.Log($"AudioClip Missing ! {path}");

        return audioClip;
    }

    public void Clear()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        _audioClips.Clear();
    }


    public void StopBGM(Define.BGM bgmType)
    {
        string bgmName = Enum.GetName(typeof(Define.BGM), bgmType);
        string path = bgmName;  // Enum.GetName(typeof(Define.BGM), bgmType)를 path로 할당

        foreach (AudioSource bgmSource in _audioSources)
        {
            if (bgmSource.isPlaying && bgmSource.clip != null && bgmSource.clip.name == bgmName)
            {
                bgmSource.Stop();
                break;
            }
        }
    }

    public void StopSFX(Define.SFX sfxType)
    {
        string sfxName = Enum.GetName(typeof(Define.SFX), sfxType);
        string path = sfxName;  // Enum.GetName(typeof(Define.SFX), sfxType)를 path로 할당

        foreach (AudioSource sfxSource in _audioSources)
        {
            if (sfxSource.isPlaying && sfxSource.clip != null && sfxSource.clip.name == sfxName)
            {
                sfxSource.Stop();
                break;
            }
        }
    }






}
