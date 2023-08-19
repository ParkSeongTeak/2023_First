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

        ///여기 건들지 말 것 위에는 원래 있던 거

        // GameManager으로 BGM 음량 정보 가져오기
        bgmAudioSource = GetComponent<AudioSource>();
        if (bgmAudioSource == null)
        {
            // AudioSource 컴포넌트가 없으면 추가
            bgmAudioSource = gameObject.AddComponent<AudioSource>();
        }

        float bgmVolume = GameManager.SoundManager.GetVolumeBGM(Define.BGM.블라썸컴퍼니_01);
        initialVolume = bgmVolume;//대입

        fadeDuration = 15.0f;

        StartCoroutine(FadeInBGMWithDelay(1.0f));//1초 뒤에 코루틴 실행

    }

    private IEnumerator FadeInBGMWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0;//이미 경과한 시간
        float startVolume = initialVolume;

        // BGM 볼륨을 0으로 줄이는 과정
        while (elapsedTime < fadeDuration)
        {
            bgmAudioSource.volume = Mathf.Lerp(startVolume, 0, elapsedTime / fadeDuration);//BGM볼륨 서서히 줄여나감
            elapsedTime += Time.deltaTime;//deltatime마다 줄어들음,경과시간 업데이트
            yield return null;
        }

        // BGM 볼륨을 다시 원래 볼륨으로 증가시키는 과정
        elapsedTime = 0;
        while (elapsedTime < fadeDuration)
        {
            bgmAudioSource.volume = Mathf.Lerp(0, initialVolume, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        bgmAudioSource.volume = initialVolume;//BGM볼륨을 처음 볼륨으로 설정 완
        isBGMFadingIn = false;
    }




}