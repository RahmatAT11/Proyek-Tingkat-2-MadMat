using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    [SerializeField]private LevelScriptableObject _currentLevel;
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

    [SerializeField] private List<Sprite> _guessPictureList;
    public List<Sprite> GuessPictureList
    {
        get
        {
            return _guessPictureList;
        }
    }

    [SerializeField]private int _totalQuestion;
    [SerializeField]private int _correctAnswer;

    public int CurrentPictureIndex { get { return _currentPictureIndex; } set { _currentPictureIndex = value; } }
    [SerializeField]private int _currentPictureIndex;

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

        List<Sprite> pictureList = _currentLevel.LevelSprites;
        foreach (Sprite sprite in pictureList)
        {
            _guessPictureList.Add(sprite);
        }
        _totalQuestion = _guessPictureList.Count;
    }

    public void ShowImage(int index)
    {
        showedImage.sprite = _guessPictureList[index];
    }
}
