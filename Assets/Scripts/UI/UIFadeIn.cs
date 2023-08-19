using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeIn : MonoBehaviour
{

    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime;
    Image _title;
    public GameObject title;

    Image _playButton;
    public GameObject playButton;

    private void Start()
    {
        playButton.SetActive(false);
        _title = title.GetComponent<Image>();
        _playButton = playButton.GetComponent<Image>();

        StartCoroutine(TitleFadeIn(0, 1));
        //StartCoroutine(PlayButtonFadeIn(0, 1));
    }


    IEnumerator TitleFadeIn(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = _title.color;
            color.a = Mathf.Lerp(start, end, percent);
            _title.color = color;

            title.transform.position += new Vector3(0, 0.2f, 0);
            yield return null;
        }

        playButton.SetActive(true);
        StartCoroutine(PlayButtonFadeIn(0, 1));

    }


    IEnumerator PlayButtonFadeIn(float start, float end)
    {

        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {

            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = _playButton.color;
            color.a = Mathf.Lerp(start, end, percent);
            _playButton.color = color;

            playButton.transform.position += new Vector3(0, 0.1f, 0);

            yield return null;

        }
    }
} 
