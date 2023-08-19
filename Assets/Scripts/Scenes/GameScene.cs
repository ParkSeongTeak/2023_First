using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameScene : MonoBehaviour
{
    private AudioSource bgmAudioSource;
    private float initialVolume;
    private bool isBGMFadingIn = false;
    private float fadeDuration;

    // Start is called before the first frame update

    private void Start()
    {

        GameManager.InGameDataManager.CreatePlayer();
        TileController.init();

        GameManager.InGameDataManager.NowState.GameDataClear();

        ///���� �ǵ��� �� �� ������ ���� �ִ� ��

        // GameManager���� BGM ���� ���� ��������
        bgmAudioSource = GetComponent<AudioSource>();
        if (bgmAudioSource == null)
        {
            // AudioSource ������Ʈ�� ������ �߰�
            bgmAudioSource = gameObject.AddComponent<AudioSource>();
        }

        float bgmVolume = GameManager.SoundManager.GetVolumeBGM(Define.BGM.�������۴�_01);
        initialVolume = bgmVolume;//����

        fadeDuration = 15.0f;

        StartCoroutine(FadeInBGMWithDelay(1.0f));//1�� �ڿ� �ڷ�ƾ ����

    }

    private IEnumerator FadeInBGMWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0;//�̹� ����� �ð�
        float startVolume = initialVolume;

        // BGM ������ 0���� ���̴� ����
        while (elapsedTime < fadeDuration)
        {
            bgmAudioSource.volume = Mathf.Lerp(startVolume, 0, elapsedTime / fadeDuration);//BGM���� ������ �ٿ�����
            elapsedTime += Time.deltaTime;//deltatime���� �پ����,����ð� ������Ʈ
            yield return null;
        }

        // BGM ������ �ٽ� ���� �������� ������Ű�� ����
        elapsedTime = 0;
        while (elapsedTime < fadeDuration)
        {
            bgmAudioSource.volume = Mathf.Lerp(0, initialVolume, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        bgmAudioSource.volume = initialVolume;//BGM������ ó�� �������� ���� ��
        isBGMFadingIn = false;
    }




}