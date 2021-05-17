using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [Header("Region")]
    [SerializeField]
    private LevelScriptableObject _level;
    public LevelScriptableObject ThisLevel
    {
        get
        {
            return _level;
        }

        set
        {
            _level = value;
        }
    }

    private Button _levelButton;

    private void Start()
    {
        _levelButton = gameObject.GetComponent<Button>();
        _levelButton.onClick.AddListener(HandleLevelButton);
    }

    private void HandleLevelButton()
    {
        GameManager.Instance.Level(this);
    }
}
