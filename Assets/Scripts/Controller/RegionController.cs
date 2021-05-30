using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class RegionController : MonoBehaviour
{
    #region Inisialisasi Variabel
    [Header("Variabel Button")]
    [SerializeField] private Button _kamarTidurButton;
    [SerializeField] private Button _kamarMandiButton;
    [SerializeField] private Button _dapurButton;
    [SerializeField] private Button _ruangMakanButton;
    [SerializeField] private Button _ruangKeluargaButton;
    [SerializeField] private Button _ruangTamuButton;
    [SerializeField] private Button _halamanDepanButton;
    [SerializeField] private Button _garasiButton;
    [SerializeField] private Button _halamanBelakangGudangButton;

    private void Start()
    {
        _kamarTidurButton.onClick.AddListener(HandleKamarTidurButton);
        _kamarMandiButton.onClick.AddListener(HandleKamarMandiButton);
        _dapurButton.onClick.AddListener(HandleDapurButton);
        _ruangMakanButton.onClick.AddListener(HandleRuangMakanButton);
        _ruangKeluargaButton.onClick.AddListener(HandleRuangKeluargaButton);
        _ruangTamuButton.onClick.AddListener(HandleRuangTamuButton);
        _halamanDepanButton.onClick.AddListener(HandleHalamanDepanButton);
        _garasiButton.onClick.AddListener(HandleGarasiButton);
        _halamanBelakangGudangButton.onClick.AddListener(HandleHalamanBelakangGudangButton);
    }
    #endregion

    #region Mekanik Load Region
    public void LoadRegion(Region region)
    {
        LevelController levelController = GameManager.Instance.UIManager.LevelController;
        levelController.LevelSOS = region.RegionSO.ThisRegionLevelSos;
        levelController.SetContainerController();

        GameManager.Instance.UIManager.ChangeMenuFragment(Fragment.LEVEL);
    }

    public void HandleKamarTidurButton()
    {
        LoadRegion(_kamarTidurButton.gameObject.GetComponent<Region>());
    }
    public void HandleKamarMandiButton()
    {
        LoadRegion(_kamarMandiButton.gameObject.GetComponent<Region>());
    }
    public void HandleDapurButton()
    {
        LoadRegion(_dapurButton.gameObject.GetComponent<Region>());
    }
    public void HandleRuangMakanButton()
    {
        LoadRegion(_ruangMakanButton.gameObject.GetComponent<Region>());
    }
    public void HandleRuangKeluargaButton()
    {
        LoadRegion(_ruangKeluargaButton.gameObject.GetComponent<Region>());
    }
    public void HandleRuangTamuButton()
    {
        LoadRegion(_ruangTamuButton.gameObject.GetComponent<Region>());
    }
    public void HandleHalamanDepanButton()
    {
        LoadRegion(_halamanDepanButton.gameObject.GetComponent<Region>());
    }
    public void HandleGarasiButton()
    {
        LoadRegion(_garasiButton.gameObject.GetComponent<Region>());
    }
    public void HandleHalamanBelakangGudangButton()
    {
        LoadRegion(_halamanBelakangGudangButton.gameObject.GetComponent<Region>());
    }
    #endregion
}

public enum RegionNames
{
    _1_KAMAR_TIDUR,
    _2_KAMAR_MANDI,
    _3_DAPUR,
    _4_RUANG_MAKAN,
    _5_RUANG_KELUARGA,
    _6_RUANG_TAMU,
    _7_HAL_DEPAN_GARASI,
    _8_HAL_BELA_GUDANG
}
