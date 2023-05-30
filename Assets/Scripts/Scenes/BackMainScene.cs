using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMainScene : MonoBehaviour
{
   public void BackMainSceneBtn()
    {
        switch (this.gameObject.name)
        {
            case "QuitBtn":
                Debug.Log("quit btn ´­¸²");
                Application.LoadLevel("Main");
                break;

        }
    }
}
