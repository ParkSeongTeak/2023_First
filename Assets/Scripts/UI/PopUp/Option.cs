using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Option : UI_PopUp
{
    enum Buttons
    {
        ESC,
        CutScenePrologueShow,
        CutSceneEpilogueShow,
        GameEnd,
    }

    enum Sliders
    {
        BGM,
        SFX,
    }



    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        //Object 바인드
        Bind<Button>(typeof(Buttons));
        Bind<Slider>(typeof(Sliders));

        BindEvent(GetButton((int)Buttons.ESC).gameObject, Btn_ESC);
        BindEvent(GetButton((int)Buttons.CutScenePrologueShow).gameObject, Btn_CutScenePrologueShow);
        BindEvent(GetButton((int)Buttons.CutSceneEpilogueShow).gameObject, Btn_CutSceneEpilogueShow);
        BindEvent(GetButton((int)Buttons.GameEnd).gameObject, GameEnd);

        if (GameManager.InGameDataManager.NeedToShowCutScene_prologue)
        {
            GetButton((int)Buttons.CutScenePrologueShow).gameObject.SetActive(false);
        }
        if (GameManager.InGameDataManager.NeedToShowCutScene_epilogue)
        {
            GetButton((int)Buttons.CutSceneEpilogueShow).gameObject.SetActive(false);
        }
        GameManager.SoundManager.SetVolume(Define.Sounds.BGM, GameManager.InGameDataManager.BGMVolume);
        GameManager.SoundManager.SetVolume(Define.Sounds.SFX, GameManager.InGameDataManager.SFXVolume);

        Get<Slider>((int)Sliders.BGM).value = GameManager.InGameDataManager.BGMVolume;
        Get<Slider>((int)Sliders.SFX).value = GameManager.InGameDataManager.SFXVolume;


        Get<Slider>((int)Sliders.BGM).onValueChanged.AddListener(delegate { VolumeChange(Define.Sounds.BGM); });
        Get<Slider>((int)Sliders.SFX).onValueChanged.AddListener(delegate { VolumeChange(Define.Sounds.SFX); });

    }
    void Btn_ESC(PointerEventData evt)
    {
        GameManager.SoundManager.Play(Define.SFX.click_01);//click_01효과음
        GameManager.UIManager.ClosePopupUI();
    }
    void Btn_CutScenePrologueShow(PointerEventData evt)
    {
        GameManager.SoundManager.Play(Define.SFX.click_02);//click_02효과음
        GameManager.UIManager.ShowPopupUI<CutScene_Prologue>();
    }


    void Btn_CutSceneEpilogueShow(PointerEventData evt)
    {
        GameManager.SoundManager.Play(Define.SFX.click_02);//click_02효과음
        GameManager.UIManager.ShowPopupUI<CutScene_Epilogue>();

    }

    void VolumeChange(Define.Sounds Sound)
    {
        float volume;
        if (Sound == Define.Sounds.BGM)
        {
            volume = Get<Slider>((int)Sliders.BGM).value;
            GameManager.InGameDataManager.BGMVolume = volume;
            
        }
        else
        {
            volume = Get<Slider>((int)Sliders.SFX).value;
            GameManager.InGameDataManager.SFXVolume = volume;
            

        }

        GameManager.SoundManager.SetVolume(Sound, volume);

    }

    void GameEnd(PointerEventData evt)
    {
        Application.Quit();
    }
}
