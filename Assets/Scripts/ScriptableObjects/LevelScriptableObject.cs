using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelScriptableObject", order = 2)]
public class LevelScriptableObject : ScriptableObject
{
    public LevelDifficulty ThisLevelDifficulty;
    public List<QuestionScriptableObject> LevelQuestions;

    public enum LevelDifficulty
    {
        EASY,
        NORMAL,
        HARD,
        VERY_HARD
    }
}
