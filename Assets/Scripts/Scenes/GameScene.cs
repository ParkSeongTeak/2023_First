using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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


    }


      

     
}