using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    // UI Manager mengatur
    // Bagaimana User Interface setiap scene (button apa yang harus ditampilkan, konten seperti apa, dll)

    #region Field
    [Header("Navigation Component")]
    [SerializeField] GameObject _appBar;
    public GameObject AppBar
    {
        get
        {
            return _appBar;
        }

        private set { }
    }

    [SerializeField] GameObject _bottomNav;
    public GameObject BottomNav
    {
        get
        {
            return _bottomNav;
        }

        private set { }
    }


    [Header("Inside Content Component")]
    [SerializeField] GameObject _selectMainMenu;
    public GameObject SelectMainMenu
    {
        get
        {
            return _selectMainMenu;
        }

        private set { }
    }

    [SerializeField] GameObject _selectRegion;
    public GameObject SelectRegion
    {
        get
        {
            return _selectRegion;
        }

        private set { }
    }

    [SerializeField] GameObject _selectLevel;
    public GameObject SelectLevel
    {
        get
        {
            return _selectLevel;
        }

        private set { }
    }

    [SerializeField] GameObject _gameplay;
    public GameObject Gameplay
    {
        get
        {
            return _gameplay;
        }

        private set { }
    }

    [SerializeField] GameObject _levelComplete;
    public GameObject LevelComplete
    {
        get
        {
            return _levelComplete;
        }

        private set { }
    }
    #endregion

    private void Start()
    {
        _selectMainMenu.SetActive(true);
        DontDestroyOnLoad(gameObject);
    }

    private void ChangeScreenTitle(string message)
    {
        ApplicationBar appBarScript = _appBar.GetComponent<ApplicationBar>();
        appBarScript.ScreenTitle.text = message;
    }

    public void ChangeActiveMenu(GameObject nextMenu, GameObject currentMenu)
    {
        string nextMenuName = nextMenu.name;
        string currentMenuName = currentMenu.name;

        switch (GameManager.Instance.CurrentFragmentState)
        {
            case FragmentState.MAIN_MENU:
                AppBar.SetActive(false);
                break;
            case FragmentState.REGION_MENU:
                AppBar.SetActive(true);
                ChangeScreenTitle(nextMenuName);
                break;
            case FragmentState.LEVEL_MENU:
                AppBar.SetActive(true);
                BottomNav.SetActive(false);
                ChangeScreenTitle(nextMenuName);
                break;
            case FragmentState.GAMEPLAY:
                AppBar.SetActive(true);
                BottomNav.SetActive(true);
                ChangeScreenTitle(nextMenuName);
                break;
            case FragmentState.LEVEL_COMPLETE:
                AppBar.SetActive(false);
                BottomNav.SetActive(false);
                ChangeScreenTitle(nextMenuName);
                break;
        }

        nextMenu.SetActive(true);
        currentMenu.SetActive(false);
    }
}
