using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    // UI Manager mengatur
    // Bagaimana User Interface setiap scene (button apa yang harus ditampilkan, konten seperti apa, dll)

    [Header("User Interface")]
    [SerializeField] GameObject _appBar;
    [SerializeField] GameObject _selectMainMenu;
    [SerializeField] GameObject _selectRegion;
    [SerializeField] GameObject _selectLevel;
    [SerializeField] GameObject _gameplay;
    [SerializeField] GameObject _levelComplete;
    [SerializeField] GameObject _bottomNav;

    private void Start()
    {
        _selectMainMenu.SetActive(true);
        DontDestroyOnLoad(gameObject);
    }

    private void OnChangeScene(GameObject currentUIContent, GameObject nextUIContent)
    {
        currentUIContent.SetActive(false);
        nextUIContent.SetActive(true);
    }
}
