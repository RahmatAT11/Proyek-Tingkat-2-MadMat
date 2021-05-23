using UnityEngine;
using UnityEngine.UI;

public class BottomNav : MonoBehaviour
{
    [Header("Important Game Object")]
    [SerializeField] private Button _prevButton;
    public Button PrevButton { get { return _prevButton; } }
    [SerializeField] private Button _nextButton;
    public Button NextButton { get { return _nextButton; } }

    // Start is called before the first frame update
    void Start()
    {
        _prevButton.onClick.AddListener(HandlePrevButton);
        _nextButton.onClick.AddListener(HandleNextButton);
    }

    private void Update()
    {
        int pictureIndex = GameManager.Instance.Current.CurrentPictureIndex;
        // hidupkan game object next button jika index gambar sekarang lebih dari 0
        if (pictureIndex > 0)
        {
            _prevButton.gameObject.SetActive(true);
        }
        else
        {
            _prevButton.gameObject.SetActive(false);
        }

        if (pictureIndex.Equals(GameManager.Instance.Current.GuessPictureList.Count - 1))
        {
            _nextButton.gameObject.SetActive(false);
        }
        else
        {
            _nextButton.gameObject.SetActive(true);
        }

        if (GameManager.Instance.Current.CorrectAnswer > 0 && GameManager.Instance.Current.CurrentPictureIndex == 
            GameManager.Instance.Current.TotalQuestion - 1)
        {
            _nextButton.gameObject.SetActive(true);
        }
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
