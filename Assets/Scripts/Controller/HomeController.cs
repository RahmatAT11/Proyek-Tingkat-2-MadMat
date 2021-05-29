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
    public GameObject HomeMenu { get { return _homeMenu; } }
    [SerializeField] private GameObject _optionMenu;
    public GameObject OptionMenu { get { return _optionMenu; } }

    private void Awake()
    {
        _playButton.onClick.AddListener(HandlePlayButton);
        _optionButton.onClick.AddListener(HandleOptionButton);
        _quitButton.onClick.AddListener(HandleQuitButton);
    }
    #endregion

    #region Handle Button Clicks
    private void HandlePlayButton()
    {
        GameManager.Instance.AudioManager.PlayButtonTap();
        GameManager.Instance.UIManager.ChangeMenuFragment(Fragment.REGION);
    }

    private void HandleOptionButton()
    {
        GameManager.Instance.AudioManager.PlayButtonTap();
        GameManager.Instance.UIManager.ChangeMenuFragment(Fragment.OPTION);
    }

    private void HandleQuitButton()
    {
        GameManager.Instance.AudioManager.PlayButtonTap();
        Application.Quit();
    }
    #endregion
}
