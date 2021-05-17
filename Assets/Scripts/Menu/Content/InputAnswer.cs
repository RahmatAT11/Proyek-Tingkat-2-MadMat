using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InputAnswer : MonoBehaviour
{
    [SerializeField] TMP_InputField _input;
    [SerializeField] TextMeshProUGUI _textEdit;

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

    public void OnFinishEditing()
    {
        string textEditString = _textEdit.text;
        string pictureName = _picture.sprite.name;

        if (textEditString.Contains(pictureName))
        {
            _answer.sprite = _right;
            gameplay.AddScore(1);
        }
        else
        {
            _answer.sprite = _wrong;
        }

        _answer.color = _normal;
    }

    public void ResetAll()
    {
        _answer.sprite = _defaultAnswer;
        _answer.color = _transparent;
        _textEdit.text = "";
    }
}
