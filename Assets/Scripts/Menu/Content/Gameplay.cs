using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    private LevelScriptableObject _currentLevel;
    public LevelScriptableObject CurrentLevel
    {
        get
        {
            return _currentLevel;
        }

        set
        {
            _currentLevel = value;
        }
    }

    private List<Sprite> _guessPictureList;
    public List<Sprite> GuessPictureList
    {
        get
        {
            return _guessPictureList;
        }
    }

    private int _totalQuestion;
    private int _correctAnswer;

    public int CurrentPictureIndex { get { return _currentPictureIndex; } set { _currentPictureIndex = value; } }
    private int _currentPictureIndex;

    public InputAnswer inputAnswer;
    public Image showedImage;

    private void Start()
    {
        _currentPictureIndex = 0;
        ShowImage(_currentPictureIndex);
    }

    public void AddScore(int score)
    {
        _correctAnswer += score;
    }

    public void SetGuessPicture()
    {
        _guessPictureList = new List<Sprite>();

        foreach (QuestionScriptableObject question in _currentLevel.LevelQuestions)
        {
            Sprite sprite = question.Picture;
            _guessPictureList.Add(sprite);
        }
        _totalQuestion = _guessPictureList.Count;
    }

    public void ShowImage(int index)
    {
        showedImage.sprite = _guessPictureList[index];
    }
}
