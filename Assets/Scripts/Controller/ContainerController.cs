using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ContainerController : MonoBehaviour
{
    #region Inisialisasi Variabel
    [Header("Quiz Image")]
    [SerializeField] private List<QuizSO> _quizSos;
    [SerializeField] private List<QuizDisplayController> _quizDisplayControllers;
    [SerializeField] private Sprite _correctPassmarkSprite;
    [SerializeField] private Sprite _wrongPassmarkSprite;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI _answeredText;
    [SerializeField] private TextMeshProUGUI _knowledgePointText;

    [Header("Button")]
    [SerializeField] private Button _containerButton;

    private readonly Color _red = Color.red;
    private readonly Color _green = Color.green;

    public List<QuizSO> QuizSOS { get { return _quizSos; } set { _quizSos = value; } }

    private float _accumulatedKnowledgePoint;

    private void Start()
    {
        #region Merubah Text quiz benar dan knowledge point
        ChangeTextAndImagePreview();
        ChangeKnowledgePoint();
        #endregion

        _containerButton.onClick.AddListener(HandleContainerButton);
    }

    private void HandleContainerButton()
    {
        QuizController quizController = GameManager.Instance.UIManager.QuizController;
        quizController.QuizSos = _quizSos;

        GameManager.Instance.UIManager.ChangeMenuFragment(Fragment.QUIZ);
        GameManager.Instance.UIManager.QuizController.UpdateDisplayQuiz();
    }

    public void InsertQuizAndDisplay()
    {
        for (int i = 0; i < _quizDisplayControllers.Count; i++)
        {
            _quizDisplayControllers[i].QuizSO = _quizSos[i];
        }
    }

    private void ChangeKnowledgePoint()
    {
        int totalCorrectAnswer = 0;
        float totalKnowledgePoint = 0;

        foreach (QuizDisplayController quizDisplayController in _quizDisplayControllers)
        {
            if (quizDisplayController.QuizSO.IsAnswerCorrect)
            {
                totalCorrectAnswer++;
                totalKnowledgePoint += quizDisplayController.QuizSO.knowledgePoint;
            }
        }
        _accumulatedKnowledgePoint = totalKnowledgePoint;
        
        _answeredText.text = $"Answered : {totalCorrectAnswer}/{_quizDisplayControllers.Count}";
        _knowledgePointText.text = $"Knowledge Points : {_accumulatedKnowledgePoint}";
    }

    private void ChangeTextAndImagePreview()
    {
        foreach (QuizDisplayController quizDisplayController in _quizDisplayControllers)
        {
            ChangePassmarkSprite(quizDisplayController.QuizSO.IsAnswerCorrect, quizDisplayController.PassmarkImage);
        }
    }
    #endregion

    #region Mekanik Image Passmark
    private void ChangePassmarkSprite(bool isCorrect, Image quizPassmarkImage)
    {
        if (isCorrect)
        {
            quizPassmarkImage.sprite = _correctPassmarkSprite;
            quizPassmarkImage.color = _green;
        }

        else
        {
            quizPassmarkImage.sprite = _wrongPassmarkSprite;
            quizPassmarkImage.color = _red;
        }
    }
    #endregion
}
