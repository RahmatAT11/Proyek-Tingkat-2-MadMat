using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputAnswer : MonoBehaviour
{
    [SerializeField] TMP_InputField _input;

    [SerializeField] Image _answer;
    [SerializeField] Sprite _right;
    [SerializeField] Sprite _wrong;
    [SerializeField] Sprite _defaultAnswer;

    [SerializeField] Image _picture;
    private Color _transparent = new Color(255, 255, 255, 0);
    private Color _normal = Color.white;

    private Gameplay gameplay;

    private void Start()
    {
        gameplay = UIManager.Instance.Gameplay.GetComponent<Gameplay>();
        _answer.sprite = _defaultAnswer;
        _answer.color = _transparent;
    }

    private void Update()
    {
        if (gameplay.CurrentLevel.LevelQuestions[gameplay.CurrentPictureIndex].AlreadyAnswered)
        {
            if (gameplay.CurrentLevel.LevelQuestions[gameplay.CurrentPictureIndex].Answer)
            {
                _answer.sprite = _right;
            }
            else
            {
                _answer.sprite = _wrong;
            }

            _answer.color = _normal;
        }
        else
        {
            _answer.sprite = _defaultAnswer;
            _answer.color = _transparent;
        }
    }

    public void OnFinishEditing()
    {
        string textEditString = _input.text;
        string pictureName = _picture.sprite.name;

        // Jika input benar
        if (textEditString.Contains(pictureName))
        {
            gameplay.CurrentLevel.LevelQuestions[gameplay.CurrentPictureIndex].AlreadyAnswered = true;
            gameplay.CurrentLevel.LevelQuestions[gameplay.CurrentPictureIndex].Answer = true;
            _answer.sprite = _right;
            gameplay.AddScore(1);
        }
        else
        {
            gameplay.CurrentLevel.LevelQuestions[gameplay.CurrentPictureIndex].AlreadyAnswered = true;
            gameplay.CurrentLevel.LevelQuestions[gameplay.CurrentPictureIndex].Answer = false;
            _answer.sprite = _wrong;
        }

        _answer.color = _normal;
    }

    public void ResetAll()
    {
        _answer.sprite = _defaultAnswer;
        _answer.color = _transparent;
        _input.text = "";
    }
}
