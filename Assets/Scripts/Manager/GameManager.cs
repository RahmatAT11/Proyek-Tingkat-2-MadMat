using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // Game Manager mengatur :
    // Perubahan scene (Scene apa yang harus di-load / ditampilkan ke layar)
    // Load Region yang dipilih di select region menu ke select level menu.
    // Memanggil Manager lain
    // Mengatur game state

    #region Field
    [Header("Managers")]
    [SerializeField] GameObject[] _systemPrefabs;
    List<GameObject> _instanceSystemPrefabs;

    [Header("UI Initialization")]
    [SerializeField] List<string> SceneName;
    #endregion

    #region Initialization
    private void Start()
    {
        _instanceSystemPrefabs = new List<GameObject>();
        InstantiateSystemPrefabs();

        DontDestroyOnLoad(gameObject);
    }

    private void InstantiateSystemPrefabs()
    {
        for (int i = 0; i < _systemPrefabs.Length; i++)
        {
            GameObject prefabsInstance = Instantiate(_systemPrefabs[i]);
            _instanceSystemPrefabs.Add(prefabsInstance);
        }
    }
    #endregion

    

    public void Play()
    {
        SceneManager.LoadScene(1);

        if (UIManager.Instance.SelectMainMenu.activeInHierarchy)
        {
            UIManager.Instance.SelectMainMenu.SetActive(false);

            UIManager.Instance.AppBar.SetActive(true);
            UIManager.Instance.SelectRegion.SetActive(true);
        }
    }

    public void Options()
    {
        Debug.Log("Opening Options Menu.....");
    }

    public void Quit()
    {
        Debug.Log("Quitting.....");
    }
}
