using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContainerController : MonoBehaviour
{
    #region Inisialisasi Variabel
    [Header("Quiz Image")]
    [SerializeField] private List<QuizSO> _quizSos;
    public List<QuizSO> QuizSOS { get { return _quizSos; } set {_quizSos = value; } }
    [SerializeField] private List<QuizDisplayController> _quizDisplayControllers;
    [SerializeField] private Sprite _correctPassmarkSprite;
    [SerializeField] private Sprite _wrongPassmarkSprite;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI _answeredText;
    [SerializeField] private TextMeshProUGUI _knowledgePointText;

    private readonly Color _red = Color.red;
    private readonly Color _green = Color.green;

    private void Start()
    {
        #region Merubah Text quiz benar dan knowledge point
        foreach (QuizDisplayController quizDisplayController in _quizDisplayControllers)
        {
            ChangePassmarkSprite(quizDisplayController.QuizSO.IsAnswerCorrect, quizDisplayController.PassmarkImage);
        }

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

        _answeredText.text = $"Answered : {totalCorrectAnswer}/{_quizDisplayControllers.Count}";
        _knowledgePointText.text = $"Knowledge Points : {totalKnowledgePoint}";
        #endregion
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

    #region Mekanik Mengisi Quiz Preview
    #endregion
}
