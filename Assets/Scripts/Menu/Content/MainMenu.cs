using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    #region Field
    [Header("Buttons")]
    [SerializeField] Button _playButton;
    [SerializeField] Button _optionsButton;
    [SerializeField] Button _quitButton;

    public UnityEvent OnPlayButtonClicked;
    public UnityEvent OnOptionsButtonClicked;
    public UnityEvent OnQuitButtonClicked;
    #endregion

    private void Start()
    {
        OnPlayButtonClicked = new UnityEvent();

        _playButton.onClick.AddListener(HandlePlayButtonListener);
        _optionsButton.onClick.AddListener(HandleOptionsButtonListener);
        _quitButton.onClick.AddListener(HandleQuitButtonListener);
    }

    private void HandlePlayButtonListener()
    {
        OnPlayButtonClicked.AddListener(GameManager.Instance.Play);

        if (OnPlayButtonClicked != null)
        {
            OnPlayButtonClicked.Invoke();
        }

        OnPlayButtonClicked.RemoveListener(GameManager.Instance.Play);
    }

    private void HandleOptionsButtonListener()
    {
        OnOptionsButtonClicked.AddListener(GameManager.Instance.Options);

        if (OnOptionsButtonClicked != null)
        {
            OnOptionsButtonClicked.Invoke();
        }

        OnOptionsButtonClicked.RemoveListener(GameManager.Instance.Options);
    }

    private void HandleQuitButtonListener()
    {
        OnQuitButtonClicked.AddListener(GameManager.Instance.Quit);

        if (OnQuitButtonClicked != null)
        {
            OnQuitButtonClicked.Invoke();
        }

        OnQuitButtonClicked.RemoveListener(GameManager.Instance.Quit);
    }

    private void OnApplicationQuit()
    {
        OnPlayButtonClicked.RemoveAllListeners();
        OnOptionsButtonClicked.RemoveAllListeners();
        OnQuitButtonClicked.RemoveAllListeners();
    }
}
