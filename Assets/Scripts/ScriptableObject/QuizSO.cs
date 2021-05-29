using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Quiz_[Difficulty]", menuName = "ScriptableObjects/QuizSO", order = 1)]
public class QuizSO : ScriptableObject
{
    [Header("Nama dan Gambar")]
    public string Name;
    public Sprite sprite;

    [Header("Terjawab dan Jawaban")]
    public bool IsAnswered;
    public bool IsAnswerCorrect;
    public string InputByUser;

    [Header("Knowledge Point")]
    public int knowledgePoint = 5;
}
