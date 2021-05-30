using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Inisialisasi Variabel
    [Header("UI Controllers")]
    [SerializeField] private AppBarController _appBarController;
    [SerializeField] private HomeController _homeController;
    [SerializeField] private RegionController _regionController;
    [SerializeField] private LevelController _levelController;
    [SerializeField] private QuizController _quizController;
    [SerializeField] private QuizCompleteController _quizCompleteController;

    public LevelController LevelController
    { get { return _levelController; } set {_levelController = value; } }
    public QuizController QuizController
    { get { return _quizController; } set { _quizController = value; } }
    public QuizCompleteController QuizCompleteController
    { get { return _quizCompleteController; } set {_quizCompleteController = value; } }

    public Fragment MenuFragment = Fragment.HOME;

    private void Start()
    {
        _appBarController.gameObject.SetActive(false);
        _homeController.gameObject.SetActive(true);
        _homeController.HomeMenu.SetActive(true);
        _homeController.OptionMenu.SetActive(false);
        _regionController.gameObject.SetActive(false);
        _levelController.gameObject.SetActive(false);
        _quizController.gameObject.SetActive(false);
        _quizCompleteController.gameObject.SetActive(false);
    }
    #endregion

    #region Mekanik Pergantian Menu
    public void ChangeMenuFragment(Fragment next)
    {
        Fragment current = MenuFragment;
        MenuFragment = next;

        switch (MenuFragment)
        {
            case Fragment.HOME:
                _homeController.gameObject.SetActive(true);
                _homeController.HomeMenu.SetActive(true);

                _homeController.OptionMenu.SetActive(false);
                _appBarController.gameObject.SetActive(false);
                _regionController.gameObject.SetActive(false);
                _levelController.gameObject.SetActive(false);
                _quizController.gameObject.SetActive(false);
                _quizCompleteController.gameObject.SetActive(false);
                break;

            case Fragment.OPTION:
                _homeController.OptionMenu.SetActive(true);
                _appBarController.gameObject.SetActive(true);
                
                _homeController.HomeMenu.SetActive(false);
                _regionController.gameObject.SetActive(false);
                _levelController.gameObject.SetActive(false);
                _quizController.gameObject.SetActive(false);
                _quizCompleteController.gameObject.SetActive(false);
                break;

            case Fragment.REGION:
                _regionController.gameObject.SetActive(true);
                _appBarController.gameObject.SetActive(true);

                _homeController.gameObject.SetActive(false);
                _homeController.OptionMenu.SetActive(false);
                _levelController.gameObject.SetActive(false);
                _quizController.gameObject.SetActive(false);
                _quizCompleteController.gameObject.SetActive(false);
                break;

            case Fragment.LEVEL:
                _levelController.gameObject.SetActive(true);
                _appBarController.gameObject.SetActive(true);

                _homeController.gameObject.SetActive(false);
                _homeController.OptionMenu.SetActive(false);
                _regionController.gameObject.SetActive(false);
                _quizController.gameObject.SetActive(false);
                _quizCompleteController.gameObject.SetActive(false);
                break;

            case Fragment.QUIZ:
                _quizController.gameObject.SetActive(true);
                _appBarController.gameObject.SetActive(true);

                _homeController.gameObject.SetActive(false);
                _homeController.OptionMenu.SetActive(false);
                _regionController.gameObject.SetActive(false);
                _levelController.gameObject.SetActive(false);
                _quizCompleteController.gameObject.SetActive(false);
                break;

            case Fragment.Q_COMPLETE:
                _quizCompleteController.gameObject.SetActive(true);

                _homeController.gameObject.SetActive(false);
                _appBarController.gameObject.SetActive(false);
                _homeController.OptionMenu.SetActive(false);
                _regionController.gameObject.SetActive(false);
                _levelController.gameObject.SetActive(false);
                _quizController.gameObject.SetActive(false);
                break;
        }
    }
    #endregion
}

public enum Fragment
{
    HOME,
    OPTION,
    REGION,
    LEVEL,
    QUIZ,
    Q_COMPLETE
}
