using UnityEngine;
using UnityEngine.UI;

public class BottomNav : MonoBehaviour
{
    [Header("Important Game Object")]
    [SerializeField] Button _prevButton;
    [SerializeField] Button _nextButton;

    // Start is called before the first frame update
    void Start()
    {
        _prevButton.onClick.AddListener(HandlePrevButton);
        _nextButton.onClick.AddListener(HandleNextButton);
    }

    private void HandleNextButton()
    {
        GameManager.Instance.Next();
    }

    private void HandlePrevButton()
    {
        GameManager.Instance.Previous();
    }
}
