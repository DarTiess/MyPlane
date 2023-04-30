using System.Collections.Generic;
using Data;
using Enemy;
using Input;
using Player;
using UnityEngine;
using UnityEngine.Serialization;


public class StartGame : MonoBehaviour
{
    [FormerlySerializedAs("levelsManager")]
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private PlayerMove playerPrefab;
    [FormerlySerializedAs("canvasPrefab")]
    [SerializeField] private UIController uiPrefab;
    [SerializeField] private EnemyMovement enemyPrefab;
    [SerializeField] private List<EnemySetting> enemySettings;

    private CameraFollow.CameraFollow mainCamera;
    private IInputService inputService;
    private GameEvents.GameStateEvents gameStateEvents;
    private UIController ui;
    private PlayerMove player;

    private void Awake()
    { 
       // sceneLoader.StartLevel();
        inputService = InputService();
        CreateGameState();
        CreateCanvas();
        CreatePlayer();
        InitCamera();
        CreateEnemies();
        gameStateEvents.StartGame();
      DontDestroyOnLoad(this);
    }

    private void CreateGameState()
    {
        gameStateEvents = new GameEvents.GameStateEvents();
        gameStateEvents.Init(sceneLoader);
    }

    private IInputService InputService()
    {
        if (Application.isEditor)
        {
            return new StandaloneInputService();
        }
        else
        {
            return new MobileInputService();
        }
    }

    private void CreateCanvas()
    {
        ui = Instantiate(uiPrefab);
        ui.Init(gameStateEvents, gameStateEvents);
    }

    private void CreatePlayer()
    {
        player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        player.Init(inputService, gameStateEvents);
    }

    private void InitCamera()
    {
        mainCamera = Camera.main.GetComponent<CameraFollow.CameraFollow>();
        mainCamera.Init(player);
    }

    private void CreateEnemies()
    {
        foreach (EnemySetting setting in enemySettings)
        {
            EnemyMovement enemy = Instantiate(enemyPrefab, GetEnemyRandomPosition(), Quaternion.identity);
            enemy.Init(gameStateEvents, player, setting);
        }
    }

    private Vector3 GetEnemyRandomPosition()
    {
        return player.transform.position - new Vector3(Random.Range(0,enemySettings.Count),Random.Range(0,enemySettings.Count));
    }
}
