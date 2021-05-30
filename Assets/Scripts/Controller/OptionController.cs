using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionController : MonoBehaviour
{
    #region Inisialisasi Variabel
    [SerializeField] private Slider _sliderMasterVolume;
    [SerializeField] private Slider _sliderMusicVolume;
    [SerializeField] private Toggle _toggleMuteVolume;
    [SerializeField] private AudioMixer _mixerMaster;
    [SerializeField] private AudioMixer _mixerMusic;

    private AudioSource _soundEffects;
    private AudioSource _bgm;

    private void Start()
    {
        _soundEffects = GameManager.Instance.AudioManager.SoundEffect;
        _bgm = GameManager.Instance.AudioManager.BackgroundMusic;
    }

    public void SetLevelMaster(float sliderValue)
    {
        _mixerMaster.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetLevelMusic(float sliderValue)
    {
        _mixerMusic.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetMuteAll(bool isOn)
    {
        _soundEffects.mute = isOn;
        _bgm.mute = isOn;
    }
    #endregion
}
