using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������ ��Ģ : ��� ������ �ݵ�� private�̴�.
/// �ݵ�� ������ get set�� ���ؼ��� �ۺ��ϰ� �Դ� ���� �� �� �ִ�.
/// �Լ����� �빮�ڷ� ��������.
/// �ۺ� �Լ��� © ���� �������ϸ� �̷� ������ �ּ� ó������.
/// ��ȯ �������� ���� (class A�� class B�� ���� , B�� C�� , C�� A��)
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Singleton
    /// <summary>
    /// ���ϼ� ������ ���Ӹ޴���
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
    /// ���ϼ� �������ִ� �Լ�
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
        //���ӿ� �� �� �̹����� �����ϰ� ���߰���?

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