using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    // UI Manager mengatur
    // Bagaimana User Interface setiap scene (button apa yang harus ditampilkan, konten seperti apa, dll)

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

    private void Start()
    {
        _selectMainMenu.SetActive(true);
        DontDestroyOnLoad(gameObject);
    }
}
