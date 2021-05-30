using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class QuizCompleteController : MonoBehaviour
{
    #region Inisialisasi Variabel
    [SerializeField] private List<Image> _stars;
    [SerializeField] private TextMeshProUGUI _correctAnswer;
    [SerializeField] private TextMeshProUGUI _knowledgePoint;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _levelMenu;

    [SerializeField] private Color _goldOrange;
    private Color _white = Color.white;

    private void Start()
    {
        _nextButton.onClick.AddListener(HandleNextButton);
        _levelMenu.onClick.AddListener(HandleLevelMenuButton);
    }

    private void HandleLevelMenuButton()
    {
        GameManager.Instance.UIManager.ChangeMenuFragment(Fragment.LEVEL);
    }

    private void HandleNextButton()
    {
        GameManager.Instance.UIManager.ChangeMenuFragment(Fragment.QUIZ);
        GameManager.Instance.UIManager.QuizController.StartingColor();
    }
    #endregion

    #region Mekanik Menampilkan Level Complete
    public void DisplayLevelComplete(float accumulatedKnowledgePoint, int correctAnswer)
    {
        QuizController quizController = GameManager.Instance.UIManager.QuizController;
        _correctAnswer.text = $"Total Correct : {correctAnswer}/{quizController.QuizSos.Count}";
        _knowledgePoint.text = $"Knowledge Points : {accumulatedKnowledgePoint}";
        ShowStar(accumulatedKnowledgePoint);

        if (GameManager.Instance.IsSaveDataCreated == false)
        {
            List<RegionSO> regionSos = GameManager.Instance.RegionSOS;
            SaveSystem.SavePlayerData(regionSos);

            GameManager.Instance.IsSaveDataCreated = true;
            int isSavedInNum = 1;
            PlayerPrefs.SetInt("SAVED", isSavedInNum);
            Debug.Log("Data is saved");
        }
    }

    private void ShowStar(float accumulatedKnowledgePoint)
    {
        if (accumulatedKnowledgePoint >= 3)
        {
            _stars[0].color = _goldOrange;
        }

        if (accumulatedKnowledgePoint >= 5)
        {
            _stars[1].color = _goldOrange;
        }

        if (accumulatedKnowledgePoint >= 7)
        {
            _stars[2].color = _goldOrange;
        }
    }
    #endregion
}
