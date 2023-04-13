using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    AudioSource[] _audioSources = new AudioSource[(int)Define.Sounds.MaxCount];
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
        }
        else
        {
            string[] soundNames = System.Enum.GetNames(typeof(Define.Sounds));
            for (int i = 0; i < soundNames.Length - 1; i++)
            {
                GameObject go = root.transform.Find(soundNames[i]).gameObject;
                _audioSources[i] = go.GetComponent<AudioSource>();
            }

            _audioSources[(int)Define.Sounds.BGM].loop = true;

        }


    }

    /// <summary>
    /// SFX용 PlayOneShot으로 구현 
    /// </summary>
    /// <param name="SFXSound"> Define.SFX Enum 에서 가져오기를 바람 </param>
    /// <param name="pitch"></param>

    public void Play(Define.SFX SFXSound, float pitch = 1.0f)
    {
        string path = Enum.GetName(typeof(Define.SFX), SFXSound);
        AudioClip audioClip = GetOrAddAudioClip(path, Define.Sounds.SFX);
        Play(audioClip, Define.Sounds.SFX, pitch);
    }
    /// <summary>
    /// BGM용 Play로 구현
    /// </summary>
    /// <param name="BGMSound">Define.BGM Enum 에서 가져오기를 바람 </param>
    /// <param name="pitch"></param>
    public void Play(Define.BGM BGMSound, float pitch = 1.0f)
    {
        string path = Enum.GetName(typeof(Define.BGM), BGMSound);
        AudioClip audioClip = GetOrAddAudioClip(path, Define.Sounds.BGM);
        Play(audioClip, Define.Sounds.BGM, pitch);
    }

    public void Play(AudioClip audioClip, Define.Sounds type = Define.Sounds.SFX, float pitch = 1.0f)
    {
        if (audioClip == null)
            return;

        if (type == Define.Sounds.BGM)
        {
            AudioSource audioSource = _audioSources[(int)Define.Sounds.BGM];
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            AudioSource audioSource = _audioSources[(int)Define.Sounds.SFX];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }
    }

    AudioClip GetOrAddAudioClip(string path, Define.Sounds type = Define.Sounds.SFX)
    {
        if (path.Contains("Sounds/") == false)
            path = $"Sounds/{path}";

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
}
