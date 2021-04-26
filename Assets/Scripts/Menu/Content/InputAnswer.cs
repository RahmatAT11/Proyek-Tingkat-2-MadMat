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

    [SerializeField] Image _picture;

    public void OnFinishEditing()
    {
        string textEditString = _textEdit.text;
        string pictureName = _picture.sprite.name;

        if (textEditString.Contains(pictureName))
        {
            _answer.sprite = _right;
        }
        else
        {
            _answer.sprite = _wrong;
        }
    }
}
