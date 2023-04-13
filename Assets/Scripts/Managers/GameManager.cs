using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 변수명 규칙 : 모든 변수는 반드시 private이다.
/// 반드시 변수는 get set을 통해서만 퍼블릭하게 왔다갔다 할 수 있다.
/// 함수명은 대문자로 시작하자.
/// 퍼블릭 함수를 짤때는 애지간하면 이런식으로 주석처리하자.
/// 순환참조 하지말자
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 유일성 보장한 게임메니저
    /// </summary>
    static GameManager _instance;
    static GameManager Instance { get { init(); return _instance; } }

    #region Managers
    InputManager _inputManager = new InputManager();
    SceneManager _sceneManager = new SceneManager();
    SoundManager _soundManager = new SoundManager();
    UIManager _uIManager = new UIManager();
    InGameDataManager _inGameDataManager = new InGameDataManager();
    public static InputManager InputManager { get{ return Instance._inputManager;  } }
    public static SceneManager SceneManager { get{ return Instance._sceneManager; }}
    public static SoundManager SoundManager { get{ return Instance._soundManager; } }
    public static UIManager UIManager { get { return Instance._uIManager; } }
    public static InGameDataManager InGameDataManager { get { return Instance._inGameDataManager; } }
    #endregion


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

            _instance._inputManager.init();
            _instance._sceneManager.init();
            _instance._soundManager.init();
            _instance._uIManager.init();
            _instance._inGameDataManager.init();


        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
    }

    // Update is called once per frame
    void Update()
    {
        InputManager.OnUpdate();
    }
}
