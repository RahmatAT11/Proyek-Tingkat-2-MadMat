using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level_[num]_Region_[name]", menuName = "ScriptableObjects/LevelSO", order = 2)]
public class LevelSO : ScriptableObject
{
    [Header("Quiz SO")]
    public List<QuizSO> ThisLevelQuizSos;
    [Header("Difficulty")]
    public Utils.LevelDifficulty LevelDifficulty;
}
