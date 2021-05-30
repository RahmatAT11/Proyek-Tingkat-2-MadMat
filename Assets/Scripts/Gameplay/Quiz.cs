using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] private QuizSO _quizSO;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;

    public QuizSO QuizSO { get { return _quizSO; } set { _quizSO = value; } }
    public string Name { get { return _name; } set { _name = value; } }
    public Sprite Sprite { get { return _sprite; } set { _sprite = value; } }

    public void SetQuiz()
    {
        _name = _quizSO.Name;
        _sprite = _quizSO.sprite;
    }
}
