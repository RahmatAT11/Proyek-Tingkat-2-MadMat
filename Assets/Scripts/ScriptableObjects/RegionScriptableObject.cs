using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Region", menuName = "ScriptableObjects/RegionScriptableObject", order = 1)]
public class RegionScriptableObject : ScriptableObject
{
    public string RegionName;
    public List<LevelScriptableObject> Levels;
}