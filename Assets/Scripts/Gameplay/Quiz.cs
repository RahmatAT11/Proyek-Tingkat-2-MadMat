using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField]
    private string _name;
    public string Name { get { return _name; } }
    [SerializeField] private Sprite _sprite;
}
