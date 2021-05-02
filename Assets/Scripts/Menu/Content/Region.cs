using UnityEngine;
using UnityEngine.UI;

public class Region : MonoBehaviour
{
    [Header("Region")]
    [SerializeField]
    private RegionScriptableObject _region;
    public RegionScriptableObject ThisRegion
    {
        get
        {
            return _region;
        }

        private set { }
    }

    private Button _regionButton;

    private void Start()
    {
        _regionButton = gameObject.GetComponent<Button>();
        _regionButton.onClick.AddListener(HandleRegionButton);
    }

    private void HandleRegionButton()
    {
        GameManager.Instance.Region();
        GameManager.Instance.LoadAllLevelOnRegionClicked(this);
    }
}
