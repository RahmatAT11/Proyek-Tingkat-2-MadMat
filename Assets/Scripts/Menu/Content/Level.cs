using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [Header("Region")]
    [SerializeField] LevelScriptableObject _level;
    public LevelScriptableObject ThisLevel
    {
        get
        {
            return _level;
        }

        private set
        {

        }
    }

    Button _levelButton;

    public UnityEvent OnLevelClicked;

    private void Start()
    {
        _levelButton = GetComponent<Button>();
        _levelButton.onClick.AddListener(HandleLevelButtonClicked);
    }

    private void HandleLevelButtonClicked()
    {
        OnLevelClicked.AddListener(GameManager.Instance.ClickLevel);

        if (OnLevelClicked != null)
        {
            OnLevelClicked.Invoke();
        }

        OnLevelClicked.RemoveListener(GameManager.Instance.ClickLevel);
    }
}
