using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private StarController _starController;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private Button _levelMenuButton;
    int score;

    private void Start()
    {
        _starController = GetComponentInChildren<StarController>();
        _levelMenuButton.onClick.AddListener(HandleLevelMenuButton);
    }

    private void HandleLevelMenuButton()
    {
        GameManager.Instance.LevelMenu();
    }

    public void SetScoreAndStar(Gameplay gameplay)
    {
        LevelScriptableObject currentLevel = gameplay.CurrentLevel;
        score = gameplay.CorrectAnswer;
        int totalQuestion = gameplay.TotalQuestion;
        int scale = 0;

        if (score > 0 && score < 4f)
        {
            scale = 1;
        }
        else if (score >= 4f && score < 7f)
        {
            scale = 2;
        }
        else if (score >= 7f && score < 10f)
        {
            scale = 3;
        }

        _score.text = $"Score : {score} / {totalQuestion}";

        _starController.SetActiveStar(scale);
    }
}
