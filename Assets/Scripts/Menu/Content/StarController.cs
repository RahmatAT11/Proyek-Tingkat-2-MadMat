using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    [SerializeField] private GameObject[] _starEmpties;

    private void OnBecameInvisible()
    {
        ResetActiveStar();
    }

    public void SetActiveStar(int scale)
    {
        for (int i = 0; i < _starEmpties.Length; i++)
        {
            if (i < scale)
            {
                _starEmpties[i].SetActive(false);
            }
        }
    }

    private void ResetActiveStar()
    {
        for (int i = 0; i < _starEmpties.Length; i++)
        {
            _starEmpties[i].SetActive(true);
        }
    }
}
