using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 변수명 규칙 : 모든 변수는 반드시 private이다.
/// 반드시 변수는 get set을 통해서만 퍼블릭하게 왔다 갔다 할 수 있다.
/// 함수명은 대문자로 시작하자.
/// 퍼블릭 함수를 짤 때는 어지간하면 이런 식으로 주석 처리하자.
/// 순환 참조하지 말자 (class A가 class B를 참조 , B가 C를 , C가 A를)
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Singleton
    /// <summary>
    /// 유일성 보장한 게임메니저
    /// </summary>

    static GameManager _instance;
    static GameManager Instance { get { init(); return _instance; } }

    GameManager() {}
    #endregion

    #region Managers
    InputManager _inputManager = new InputManager();
    SceneManager _sceneManager = new SceneManager();
    SoundManager _soundManager = new SoundManager();
    UIManager _uIManager = new UIManager();
    InGameDataManager _inGameDataManager = new InGameDataManager();
    ResourceManager _resourceManager = new ResourceManager();
    public static InputManager InputManager { get{ return Instance._inputManager;  } }
    public static SceneManager SceneManager { get{ return Instance._sceneManager; }}
    public static SoundManager SoundManager { get{ return Instance._soundManager; } }
    public static UIManager UIManager { get { return Instance._uIManager; } }
    public static InGameDataManager InGameDataManager { get { return Instance._inGameDataManager; } }
    public static ResourceManager ResourceManager { get { return Instance._resourceManager; } }
    #endregion



    #region Initiate
    /// <summary>
    /// 유일성 보장해주는 함수
    /// </summary>
    private static void init()
    {
        if(_instance == null)
        {
            GameObject gm = GameObject.Find("GameManager");
            if(gm == null)
            {
                gm = new GameObject { name = "GameManager" };
                gm.AddComponent<GameManager>();
            }
            DontDestroyOnLoad(gm);
            _instance = gm.GetComponent<GameManager>();

            _instance._inGameDataManager.init();
            _instance._inputManager.init();
            _instance._sceneManager.init();
            _instance._soundManager.init();
            _instance._uIManager.init();


        }
    }
    #endregion

    private void Awake()
    {
        init();
    }

    public static void GameStart()
    {
        //게임에 들어갈 꽃 이미지를 결정하고 들어가야겠죠?

    }

    public static void GameOver(float timer)
    {
        _instance.Invoke("GameOver", timer);
    }
    void GameOver()
    {
        Debug.Log("GameOver");
        //UIManager.PopUpUI[(int)Define.PopUpUI.GameOverMenu].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        InputManager.OnUpdate();
    }
}