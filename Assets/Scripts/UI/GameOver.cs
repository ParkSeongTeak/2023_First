using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    //public GameObject gameOverMenu;
    GameObject _gameOverMenu;
    public GameObject GameOverMenu { get { return _gameOverMenu; } }

    void Awake()
    {
        _gameOverMenu = GameObject.Find("GameOverMenu"); 
    }

    public void EnableGameOverMenu()
    {
        if (_gameOverMenu != null)
        {
            GameManager.SoundManager.StopBGM(Define.BGM.�������۴�_01);
            Debug.Log("����");
            _gameOverMenu.SetActive(true);
            

        }
    }

    public void DisableGameOverMenu()
    {
        if (_gameOverMenu != null)
        {
            _gameOverMenu.SetActive(false);

        }
    }

    /*
    public void GameOverNow()
    {
        GameManager.UIManager.ShowSceneUI<GameUI>().LifeIcon.SetActive(false);
        GameManager.InGameDataManager.NowState.LifeCnt--;
    }
    */

    
}
