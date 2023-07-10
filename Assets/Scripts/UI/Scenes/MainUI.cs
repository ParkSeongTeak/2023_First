using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : UI_Scene
{
    enum Buttons
    {
        ModeButton,
        InfoButton,
        SettingButton,
        GotoGameButton,
        GardenTab,
        SkinTab,
        SelectTileButton,
    }

    enum Texts
    {
        JumpCnt,
        SkipCnt,
        BloomCnt,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

    }
}
