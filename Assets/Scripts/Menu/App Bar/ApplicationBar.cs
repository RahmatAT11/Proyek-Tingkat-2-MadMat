using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

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

    public UnityEvent OnBackButtonClicked;
    
    private void Start()
    {
        _backButton.onClick.AddListener(HandleBackButtonListener);
    }

    private void HandleBackButtonListener()
    {
        OnBackButtonClicked.AddListener(GameManager.Instance.BackFromRegion);

        OnBackButtonClicked.AddListener(GameManager.Instance.BackFromLevel);

        OnBackButtonClicked.AddListener(GameManager.Instance.BackFromGameplay);

        if (OnBackButtonClicked != null)
        {
            OnBackButtonClicked.Invoke();
        }

        OnBackButtonClicked.RemoveAllListeners();
    }

    private void OnApplicationQuit()
    {
        OnBackButtonClicked.RemoveAllListeners();
    }
}
