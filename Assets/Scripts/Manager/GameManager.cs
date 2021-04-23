using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    // Game Manager mengatur :
    // Perubahan scene (Scene apa yang harus di-load / ditampilkan ke layar)
    // Load Region yang dipilih di select region menu ke select level menu.
    // Memanggil Manager lain
    // Mengatur game state

    #region Field
    [Header("Managers")]
    [SerializeField] GameObject[] _systemPrefabs;
    List<GameObject> _instanceSystemPrefabs;

    [Header("UI Initialization")]
    [SerializeField] List<string> SceneName;

    // Handling Game Scene
    GameScene _currentGameScene = GameScene.MAIN_MENU;
    public GameScene CurrentGameScene
    {
        get
        {
            return _currentGameScene;
        }
    }

    public UnityEvent<GameScene, GameScene> OnGameSceneChanged;

    #endregion

    #region Initialization
    private void Start()
    {
        _instanceSystemPrefabs = new List<GameObject>();
        InstantiateSystemPrefabs();

        DontDestroyOnLoad(gameObject);
    }

    private void InstantiateSystemPrefabs()
    {
        for (int i = 0; i < _systemPrefabs.Length; i++)
        {
            GameObject prefabsInstance = Instantiate(_systemPrefabs[i]);
            _instanceSystemPrefabs.Add(prefabsInstance);
        }
    }

    public void LoadAllLevelOnRegionClicked(Region region)
    {
        int index = 0;

        foreach (LevelScriptableObject levelScriptable in region.ThisRegion.Levels)
        {
            LevelMenu levelMenu = UIManager.Instance.SelectLevel.GetComponent<LevelMenu>();
            levelMenu.LevelObjects[index].GetComponent<Level>().ThisLevel = levelScriptable;
            index++;
        }

        index = 0;
    }
    #endregion


    #region Button Funtionality
    public void Play()
    {
        SceneManager.LoadScene(1);

        if (UIManager.Instance.SelectMainMenu.activeInHierarchy)
        {
            UIManager.Instance.SelectMainMenu.SetActive(false);

            UIManager.Instance.AppBar.SetActive(true);
            UIManager.Instance.SelectRegion.SetActive(true);
        }

        _currentGameScene = GameScene.REGION_MENU;
    }

    public void Options()
    {
        Debug.Log("Opening Options Menu.....");
    }

    public void Quit()
    {
        Debug.Log("Quitting.....");
    }

    public void BackFromRegion()
    {
        SceneManager.LoadScene(0);

        if (UIManager.Instance.SelectRegion.activeInHierarchy)
        {
            UIManager.Instance.SelectRegion.SetActive(false);

            UIManager.Instance.AppBar.SetActive(false);
            UIManager.Instance.SelectMainMenu.SetActive(true);
        }

        _currentGameScene = GameScene.MAIN_MENU;
    }

    public void BackFromLevel()
    {
        SceneManager.LoadScene(1);

        if (UIManager.Instance.SelectLevel.activeInHierarchy)
        {
            UIManager.Instance.SelectLevel.SetActive(false);

            UIManager.Instance.AppBar.SetActive(true);
            UIManager.Instance.SelectRegion.SetActive(true);
        }

        _currentGameScene = GameScene.REGION_MENU;
    }

    public void BackFromGameplay()
    {
        SceneManager.LoadScene(0);

        if (UIManager.Instance.Gameplay.activeInHierarchy)
        {
            UIManager.Instance.Gameplay.SetActive(false);
            UIManager.Instance.BottomNav.SetActive(false);

            UIManager.Instance.AppBar.SetActive(true);
            UIManager.Instance.SelectLevel.SetActive(true);
        }

        _currentGameScene = GameScene.LEVEL_MENU;
    }

    public void ClickRegion()
    {
        SceneManager.LoadScene(2);

        UIManager.Instance.GoToRegionMenu();

        _currentGameScene = GameScene.LEVEL_MENU;
    }

    public void ClickLevel()
    {
        SceneManager.LoadScene(3);

        UIManager.Instance.GoToLevelMenu();

        _currentGameScene = GameScene.GAMEPLAY;
    }
    #endregion

    public enum GameScene
    {
        MAIN_MENU,
        REGION_MENU,
        LEVEL_MENU,
        GAMEPLAY
    }
}
