using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Tmp : MonoBehaviour
{
    // Start is called before the first frame update
    public void BtnSound()
    {
        //GameManager.SoundManager.Play(Define.SFX.BlockClear);
        for (int i = 0; i < 2; i++)
            Debug.Log(GameManager.InGameDataManager.ScenarioHandler[$"{0}_{i}"].Dialogue);

        
    }
}
