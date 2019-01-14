using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public enum GameScene
{
    MainMenu = 0, Level = 1
}

public class GameController : MonoBehaviour
{
    private GameScene gameScene;

    [Tooltip(" Время перед загрузкой сцены.\n За это время должны успеть сработать все эфекты по смене сцены")]
    [SerializeField] private float leaveSceneTimeDelay;

    [SerializeField] private AnySceneEvents anySceneEvents;
    [SerializeField] private MenuEvents menuEvents;
    [SerializeField] private LevelEvents levelEvents;

    void OnValidate()
    {
        if (gameScene < 0)
            gameScene = 0;
    }
    void Start()
    {
        StartMenuScene();
    }

    // Меню
    public void StartMenuScene()
    {
        gameScene = GameScene.MainMenu;
        anySceneEvents.StartAnySceneEvent.Invoke();
        menuEvents.StartMenuSceneEvent.Invoke();
    }
    public void LeaveMenuScene(int newScene)
    {
        anySceneEvents.LeaveAnySceneEvent.Invoke();
        menuEvents.LeaveMenuSceneEvent.Invoke();
        StartCoroutine(LeaveMenuSceneCorutine(newScene));
    }
    private IEnumerator LeaveMenuSceneCorutine(int newScene)
    {
        yield return new WaitForSeconds(leaveSceneTimeDelay);
        if ((GameScene)newScene == GameScene.Level)
            StartLevelScene();
    }

    // Уровни
    public void StartLevelScene()
    {
        gameScene = GameScene.Level;
        anySceneEvents.StartAnySceneEvent.Invoke();
        levelEvents.StartLevelSceneEvent.Invoke();
    }
    public void LeaveLevelScene()
    {
        anySceneEvents.LeaveAnySceneEvent.Invoke();
        levelEvents.LeaveLevelSceneEvent.Invoke();
        StartCoroutine(LeaveLevelSceneCorutine());
    }
    private IEnumerator LeaveLevelSceneCorutine()
    {
        yield return new WaitForSeconds(leaveSceneTimeDelay);
        StartMenuScene();
    }
}

[System.Serializable]
class AnySceneEvents
{
    public UnityEvent StartAnySceneEvent;
    public UnityEvent LeaveAnySceneEvent;
}

[System.Serializable]
class MenuEvents
{
    public UnityEvent StartMenuSceneEvent;
    public UnityEvent LeaveMenuSceneEvent;
}

[System.Serializable]
class LevelEvents
{
    public UnityEvent StartLevelSceneEvent;
    public UnityEvent LeaveLevelSceneEvent;
}


