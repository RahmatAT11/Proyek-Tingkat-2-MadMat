using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Region_[RegName]", menuName = "ScriptableObjects/RegionSO", order = 3)]
public class RegionSO : ScriptableObject
{
    [Header("Nama dan LevelSO")]
    public string RegionName;
    public List<LevelSO> ThisRegionLevelSos;
}
