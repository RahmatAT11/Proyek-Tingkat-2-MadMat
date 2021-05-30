using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int savedKnowledgePoint;
    public List<RegionSO> savedRegionSO;

    public PlayerData(List<RegionSO> regionSOs)
    {
        savedRegionSO = regionSOs;
    }
}
