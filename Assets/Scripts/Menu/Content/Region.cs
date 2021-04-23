using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Region : MonoBehaviour
{
    [Header("Region")]
    [SerializeField] RegionScriptableObject _region;
    public RegionScriptableObject ThisRegion
    {
        get
        {
            return _region;
        }

        private set { }
    }
    Button _regionButton;

    public UnityEvent OnRegionClicked;

    private void Start()
    {
        _regionButton = GetComponent<Button>();
        _regionButton.onClick.AddListener(HandleRegionButtonClicked);
    }

    private void HandleRegionButtonClicked()
    {
        OnRegionClicked.AddListener(GameManager.Instance.ClickRegion);

        GameManager.Instance.LoadAllLevelOnRegionClicked(this);

        if (OnRegionClicked != null)
        {
            OnRegionClicked.Invoke();
        }

        OnRegionClicked.RemoveListener(GameManager.Instance.ClickRegion);
    }
}
