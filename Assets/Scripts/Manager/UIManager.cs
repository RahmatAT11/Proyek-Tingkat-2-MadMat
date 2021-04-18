﻿using System.Collections;
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

    private void Update()
    {
        if (GameManager.Instance.CurrentGameScene == GameManager.GameScene.REGION_MENU)
        {
            ApplicationBar appBarScript = _appBar.GetComponent<ApplicationBar>();
            appBarScript.ScreenTitle.text = "Choose Region";
        }

        if (GameManager.Instance.CurrentGameScene == GameManager.GameScene.LEVEL_MENU)
        {
            ApplicationBar appBarScript = _appBar.GetComponent<ApplicationBar>();
            appBarScript.ScreenTitle.text = "Choose Level";
        }

        if (GameManager.Instance.CurrentGameScene == GameManager.GameScene.GAMEPLAY)
        {
            ApplicationBar appBarScript = _appBar.GetComponent<ApplicationBar>();
            appBarScript.ScreenTitle.text = "Level";
        }
    }

    public void GoToRegionMenu()
    {
        if (SelectRegion.activeInHierarchy)
        {
            SelectRegion.SetActive(false);

            AppBar.SetActive(true);
            SelectLevel.SetActive(true);
        }
    }

    public void GoToLevelMenu()
    {
        if (SelectLevel.activeInHierarchy)
        {
            SelectLevel.SetActive(false);

            AppBar.SetActive(true);
            BottomNav.SetActive(true);
            Gameplay.SetActive(true);
        }
    }
}
