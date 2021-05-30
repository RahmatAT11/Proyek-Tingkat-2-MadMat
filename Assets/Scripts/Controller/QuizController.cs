using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizController : MonoBehaviour
{
    #region Inisialisasi Variabel
    [Header("Variabel User Interface")]
    [SerializeField] private Image _quizImage;
    [SerializeField] private Quiz _quizDisplayed;
    [SerializeField] private TMP_InputField _quizInput;
    [SerializeField] private Image _quizCorrectImage;
    [SerializeField] private List<QuizSO> _quizSos;

    [Header("Quiz Correct Image Sprite")]
    [SerializeField] private Sprite _quizCorrectSprite;
    [SerializeField] private Sprite _quizWrongSprite;

    private Color transparent = new Color(255, 255, 255, 0);
    private Color normal = Color.white;

    private int index = 0;

    private float accumulatedKnowledgePoint = 0;
    private int correctAnswer = 0;

    public List<QuizSO> QuizSos { get { return _quizSos; } set {_quizSos = value; } }

    private void Awake()
    {
        StartingColor();
    }

    private void Update()
    {
        
    }
    #endregion

    #region Mekanik Pengecekan Jawaban User
    public void AnswerChecking()
    {
        string input = _quizInput.text.ToLower();
        string answer = _quizDisplayed.Name.ToLower();
        bool isCorrect = input == answer;

        if (isCorrect)
        {
            accumulatedKnowledgePoint += _quizDisplayed.QuizSO.knowledgePoint;
            correctAnswer++;
            _quizDisplayed.QuizSO.InputByUser = answer;

            _quizDisplayed.QuizSO.IsAnswered = true;

            GameManager.Instance.AudioManager.PlayAfterCheckUserInput(isCorrect);
            _quizCorrectImage.sprite = _quizCorrectSprite;
            index++;
        }

        else
        {
            GameManager.Instance.AudioManager.PlayAfterCheckUserInput(isCorrect);
            _quizCorrectImage.sprite = _quizWrongSprite;
        }

        _quizDisplayed.QuizSO.IsAnswerCorrect = isCorrect;
        _quizCorrectImage.color = normal;
        StartCoroutine(WaitForSecs(3.5f));
    }

    public void UpdateDisplayQuiz()
    {
        if (index == _quizSos.Count)
        {
            GameManager.Instance.AudioManager.PlayLevelComplete();
            GameManager.Instance.UIManager.ChangeMenuFragment(Fragment.Q_COMPLETE);
            GameManager.Instance.UIManager.QuizCompleteController
                .DisplayLevelComplete(accumulatedKnowledgePoint, correctAnswer);
            index = 0;
            accumulatedKnowledgePoint = 0;
            correctAnswer = 0;
            return;
        }
        _quizDisplayed.QuizSO = _quizSos[index];
        _quizDisplayed.SetQuiz();
        StartingColor();
    }

    public void StartingColor()
    {
        _quizCorrectImage.sprite = _quizCorrectSprite;
        _quizCorrectImage.color = transparent;
        _quizInput.text = "";
        _quizImage.sprite = _quizDisplayed.QuizSO.sprite;
    }

    private IEnumerator WaitForSecs(float second)
    {
        yield return new WaitForSecondsRealtime(second);

        UpdateDisplayQuiz();
    }
    #endregion
}
