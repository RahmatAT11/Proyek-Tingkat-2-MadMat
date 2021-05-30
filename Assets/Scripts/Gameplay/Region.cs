using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    #region Inisialisasi Variabel
    [Header("Region SO")]
    [SerializeField] private RegionSO _regionSO;
    public RegionSO RegionSO { get { return _regionSO; } }

    private void Start()
    {
        if (GameManager.Instance.IsSaveDataCreated)
        {
            for (int i = 0; i < GameManager.Instance.RegionSOS.Count; i++)
            {
                if (GameManager.Instance.RegionSOS[i] == _regionSO)
                {
                    _regionSO = GameManager.Instance.RegionSOS[i];
                }
            }
        }
    }
    #endregion
}
