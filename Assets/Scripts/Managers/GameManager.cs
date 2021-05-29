
public class GameManager : Singleton<GameManager>
{
    #region Inisialisasi Variabel
    private UIManager _uiManager;
    public UIManager UIManager { get { return _uiManager; } }
    private AudioManager _audioManager;
    public AudioManager AudioManager { get { return _audioManager; } }

    private void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _audioManager = FindObjectOfType<AudioManager>();
    }
    #endregion
}
