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
    [SerializeField] List<string> _sceneName;

    // Handling Fragment of the Game
    private FragmentState _currentFragmentState = FragmentState.MAIN_MENU;
    public FragmentState CurrentFragmentState
    {
        get
        {
            return _currentFragmentState;
        }
    }

    public UnityAction<FragmentState, FragmentState> OnFragmentChanged = delegate { };

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
        ChangeFragment(FragmentState.REGION_MENU, FragmentState.MAIN_MENU);

        GameObject nextMenu = UIManager.Instance.SelectRegion;
        GameObject currentMenu = UIManager.Instance.SelectMainMenu;

        UIManager.Instance.ChangeActiveMenu(nextMenu, currentMenu);
    }

    public void Options()
    {
        Debug.Log("Opening Options Menu.....");
    }

    public void Quit()
    {
        Debug.Log("Quitting.....");
        Application.Quit();
    }
    
    public void Back()
    {
        GameObject nextMenu = null;
        GameObject currentMenu = null;

        switch (_currentFragmentState)
        {
            case FragmentState.REGION_MENU:
                ChangeFragment(FragmentState.MAIN_MENU, FragmentState.REGION_MENU);
                nextMenu = UIManager.Instance.SelectMainMenu;
                currentMenu = UIManager.Instance.SelectRegion;
                UIManager.Instance.ChangeActiveMenu(nextMenu, currentMenu);
                break;
            case FragmentState.LEVEL_MENU:
                ChangeFragment(FragmentState.REGION_MENU, FragmentState.LEVEL_MENU);
                nextMenu = UIManager.Instance.SelectRegion;
                currentMenu = UIManager.Instance.SelectLevel;
                UIManager.Instance.ChangeActiveMenu(nextMenu, currentMenu);
                break;
            case FragmentState.GAMEPLAY:
                ChangeFragment(FragmentState.LEVEL_MENU, FragmentState.GAMEPLAY);
                nextMenu = UIManager.Instance.SelectLevel;
                currentMenu = UIManager.Instance.Gameplay;
                UIManager.Instance.ChangeActiveMenu(nextMenu, currentMenu);
                break;
        }
    }

    public void Region()
    {
        ChangeFragment(FragmentState.LEVEL_MENU, FragmentState.REGION_MENU);

        GameObject nextMenu = UIManager.Instance.SelectLevel;
        GameObject currentMenu = UIManager.Instance.SelectRegion;

        UIManager.Instance.ChangeActiveMenu(nextMenu, currentMenu);
    }

    public void Level()
    {
        ChangeFragment(FragmentState.GAMEPLAY, FragmentState.LEVEL_MENU);

        GameObject nextMenu = UIManager.Instance.Gameplay;
        GameObject currentMenu = UIManager.Instance.SelectLevel;

        UIManager.Instance.ChangeActiveMenu(nextMenu, currentMenu);
    }

    #endregion

    #region Fragment Change Functionality
    void ChangeFragment(FragmentState next, FragmentState current)
    {
        // Perubahan fragment terjadi jika memiliki fragment lanjutannya
        // Fragment akan diubah sesuai fragment selanjutnya
        FragmentState previous = _currentFragmentState;

        switch (next)
        {
            case FragmentState.MAIN_MENU:
                _currentFragmentState = next;
                break;
            case FragmentState.REGION_MENU:
                _currentFragmentState = next;
                break;
            case FragmentState.LEVEL_MENU:
                _currentFragmentState = next;
                break;
            case FragmentState.GAMEPLAY:
                _currentFragmentState = next;
                break;
            case FragmentState.LEVEL_COMPLETE:
                _currentFragmentState = next;
                break;
        }

        OnFragmentChanged(_currentFragmentState, previous);
    }
    #endregion
}
