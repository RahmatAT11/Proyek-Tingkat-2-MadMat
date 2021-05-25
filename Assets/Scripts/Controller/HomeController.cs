using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    #region Inisialisasi Variabel
    [Header("Variabel Button")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _optionButton;
    [SerializeField] private Button _quitButton;

    [Header("Variabel User Interface")]
    [SerializeField] private GameObject _homeMenu;
    [SerializeField] private GameObject _optionMenu;

    private void Awake()
    {
        //_playButton.onClick.AddListener();
        //_optionButton.onClick.AddListener();
        //_quitButton.onClick.AddListener();
    }
    #endregion
}
