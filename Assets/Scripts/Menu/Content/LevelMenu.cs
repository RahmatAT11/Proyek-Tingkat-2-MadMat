using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] List<GameObject> _levelObjects;
    public List<GameObject> LevelObjects
    {
        get
        {
            return _levelObjects;
        }

        private set { }
    }
}