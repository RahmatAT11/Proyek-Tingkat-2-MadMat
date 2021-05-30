using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    #region Inisialisasi Variabel
    private UIManager _uiManager;
    public UIManager UIManager { get { return _uiManager; } }
    private AudioManager _audioManager;
    public AudioManager AudioManager { get { return _audioManager; } }

    public List<RegionSO> RegionSOS { get; set; }

    public bool IsSaveDataCreated { get; set; }

    private void Start()
    {
        int isSaved = PlayerPrefs.GetInt("SAVED", 0);
        if (isSaved == 1)
        {
            IsSaveDataCreated = true;
        }

        if (IsSaveDataCreated == true)
        {
            PlayerData playerData = SaveSystem.LoadPlayerData();
            RegionSOS = playerData.savedRegionSO;
        }

        _uiManager = FindObjectOfType<UIManager>();
        _audioManager = FindObjectOfType<AudioManager>();
    }
    #endregion
}
