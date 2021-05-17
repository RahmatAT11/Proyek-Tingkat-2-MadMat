using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "ScriptableObjects/QuestionScriptableObject", order = 3)]
public class QuestionScriptableObject : ScriptableObject
{
    public bool AlreadyAnswered;
    public bool Answer;
    public Sprite Picture;
}
