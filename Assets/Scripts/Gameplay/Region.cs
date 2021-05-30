using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    #region Inisialisasi Variabel
    [Header("Region SO")]
    [SerializeField] private RegionSO _regionSO;
    public RegionSO RegionSO { get { return _regionSO; } }
    #endregion
}
