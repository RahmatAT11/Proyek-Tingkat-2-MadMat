using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Game Manager mengatur :
    // Perubahan scene (Scene apa yang harus di-load / ditampilkan ke layar)
    // Load Region yang dipilih di select region menu ke select level menu.
    // Memanggil Manager lain
    // Mengatur game state

    [Header("Managers")]
    [SerializeField] GameObject UIManager;
    Canvas _uiManagerCanvas;

    [Header("UI Initialization")]
    [SerializeField] List<string> SceneName;

    private void Start()
    {
        Instantiate(UIManager);

        DontDestroyOnLoad(gameObject);
    }
}
