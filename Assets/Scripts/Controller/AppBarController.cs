using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class AppBarController : MonoBehaviour
{
    #region Inisialisasi Variabel
    [Header("Variabel Button")]
    [SerializeField] private Button _upButton;

    [Header("Variabel Text")]
    [SerializeField] private TextMeshProUGUI _titleText;

    private void Start()
    {
        _upButton.onClick.AddListener(HandleUpButton);
    }

    public void ChangeTitleText()
    {
        switch (GameManager.Instance.UIManager.MenuFragment)
        {
            case Fragment.OPTION:
                _titleText.text = "Option";
                break;
            case Fragment.REGION:
                _titleText.text = "Region Menu";
                break;
            case Fragment.LEVEL:
                _titleText.text = "Level Menu";
                break;
            case Fragment.QUIZ:
                _titleText.text = "Quiz";
                break;
        }
    }

    private void HandleUpButton()
    {
        GameManager.Instance.AudioManager.PlayButtonTap();

        Fragment current = GameManager.Instance.UIManager.MenuFragment;

        Fragment next = Fragment.HOME;

        switch (current)
        {
            case Fragment.OPTION:
                next = Fragment.HOME;
                break;
            case Fragment.REGION:
                next = Fragment.HOME;
                break;
            case Fragment.LEVEL:
                next = Fragment.REGION;
                break;
            case Fragment.QUIZ:
                next = Fragment.LEVEL;
                break;
        }

        GameManager.Instance.UIManager.ChangeMenuFragment(next);
    }
    #endregion
}
