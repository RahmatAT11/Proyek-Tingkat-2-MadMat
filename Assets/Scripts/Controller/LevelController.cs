using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    #region Inisialisasi Variabel
    [SerializeField] private List<LevelSO> _levelSOS;
    public List<LevelSO> LevelSOS { get { return _levelSOS; } set { _levelSOS = value; } }
    [SerializeField] private List<ContainerController> _containerControllers;
    public List<ContainerController> ContainerControllers
    { get {return _containerControllers; } set {_containerControllers = value; } }
    #endregion

    #region Mekanik Pengisian ContainerController
    public void SetContainerController()
    {
        for (int i = 0; i < _levelSOS.Count; i++)
        {
            _containerControllers[i].QuizSOS = _levelSOS[i].ThisLevelQuizSos;
            _containerControllers[i].InsertQuizAndDisplay();
            _containerControllers[i].ChangeKnowledgePoint();
            _containerControllers[i].ChangeTextAndImagePreview();
        }
    }
    #endregion
}
