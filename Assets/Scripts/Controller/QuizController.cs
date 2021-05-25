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
    [SerializeField] private TMP_InputField _quizInput;
    [SerializeField] private Image _quizCorrectImage;

    [Header("Quiz Correct Image Sprite")]
    [SerializeField] private Sprite _quizCorrectSprite;
    [SerializeField] private Sprite _quizWrongSprite;

    private Color transparent = new Color(255, 255, 255, 0);
    private Color normal = Color.white;

    private void Awake()
    {
        _quizCorrectImage.sprite = _quizCorrectSprite;
        _quizCorrectImage.color = transparent;
    }
    #endregion


}
