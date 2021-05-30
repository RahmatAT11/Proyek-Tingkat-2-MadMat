using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Inisialisasi Variabel
    [Header("Audio Sources")]
    //[SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _soundEffect;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip _buttonTapSfx;
    [SerializeField] private AudioClip _levelCompleteSfx;
    [SerializeField] private AudioClip _wrondAnswerSfx;
    [SerializeField] private AudioClip _correctAnswerSfx;
    #endregion

    #region Mekanik Play Sound
    public void PlayButtonTap()
    {
        _soundEffect.PlayOneShot(_buttonTapSfx);
    }

    public void PlayLevelComplete()
    {
        _soundEffect.PlayOneShot(_levelCompleteSfx);
    }

    public void PlayAfterCheckUserInput(bool isCorrect)
    {
        if (isCorrect)
        {
            _soundEffect.PlayOneShot(_correctAnswerSfx);
        }
        else
        {
            _soundEffect.PlayOneShot(_wrondAnswerSfx);
        }
    }
    #endregion

    #region Mekanik Mengubah Volume
    #endregion
}
