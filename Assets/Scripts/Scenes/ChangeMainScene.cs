using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMainScene : MonoBehaviour
{
    //     Application.LoadLevel("Main");

    public void ChangeSceneButtons()
    {
        switch(this.gameObject.name)
        {
            case "GotoGameButton":
                Application.LoadLevel("Game");
                break;
   
        }
    }
}
