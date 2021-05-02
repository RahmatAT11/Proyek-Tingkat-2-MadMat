using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System;

public class ApplicationBar : MonoBehaviour
{
    [Header("Important Game Objects")]
    [SerializeField] Button _backButton;
    [SerializeField] TextMeshProUGUI _screenTitle;
    public TextMeshProUGUI ScreenTitle
    {
        get
        {
            return _screenTitle;
        }

        set
        {
            _screenTitle = value;
        }
    }

    private void Start()
    {
        _backButton.onClick.AddListener(HandleBackButton);
    }

    private void HandleBackButton()
    {
        GameManager.Instance.Back();
    }
}
