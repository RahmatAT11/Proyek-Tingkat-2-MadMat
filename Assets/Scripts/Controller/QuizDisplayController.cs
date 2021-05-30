using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizDisplayController : MonoBehaviour
{
    #region Inisialisasi Variabel
    [Header("ScriptableObject and Image Passmark")]
    [SerializeField] private QuizSO _quizSO;
    [SerializeField] private Image _passmarkImage;

    public QuizSO QuizSO { get { return _quizSO; } set {_quizSO = value; } }
    public Image PassmarkImage { get { return _passmarkImage; } }
    #endregion
}
