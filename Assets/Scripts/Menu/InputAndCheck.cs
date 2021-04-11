using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputAndCheck : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _inputJawabanText;
    [SerializeField] private TextMeshProUGUI _displayAnswerText;

    private GameObject _objectToGuess;

    private void Start()
    {
        _objectToGuess = GameObject.Find("Kubus");
    }

    // Cek apakah jawaban benar
    public void OnInputChangeEnd()
    {
        if (_inputJawabanText.text.Contains(_objectToGuess.name))
        {
            _displayAnswerText.text = "Benar";
        }
        else
        {
            _displayAnswerText.text = "Salah";
        }
    }
}
