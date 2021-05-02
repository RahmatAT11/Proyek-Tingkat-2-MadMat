using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region Field
    [Header("Buttons")]
    [SerializeField] Button _playButton;
    [SerializeField] Button _optionsButton;
    [SerializeField] Button _quitButton;
    #endregion

    private void Start()
    {
        _playButton.onClick.AddListener(HandlePlayBUtton);
    }

    private void HandlePlayBUtton()
    {
        GameManager.Instance.Play();
    }
}
