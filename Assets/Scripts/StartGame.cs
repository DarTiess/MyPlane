using System.Collections.Generic;
using Data;
using Enemy;
using Input;
using Player;
using UnityEngine;


public class StartGame : MonoBehaviour
{
    [SerializeField] private LevelsManager levelsManager;
    [SerializeField] private PlayerMove playerPrefab;
    [SerializeField] private CanvasController canvasPrefab;
    [SerializeField] private EnemyMovement enemyPrefab;
    [SerializeField] private List<EnemySetting> enemySettings;

    private CameraFollow.CameraFollow mainCamera;
    private IInputService inputService;
    private GameEvents.GameEvents gameEvents;
    private CanvasController canvas;
    private PlayerMove player;

    private void Awake()
    {
      //  levelsManager.StartGame();
      inputService = InputService();

      gameEvents = new GameEvents.GameEvents();
      
      CreateCanvas();

      CreatePlayer();

      InitCamera();

      CreateEnemies();
      
      gameEvents.StartGame();

     DontDestroyOnLoad(this);
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
        canvas = Instantiate(canvasPrefab);
        canvas.Init(gameEvents);
    }

    private void CreatePlayer()
    {
        player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        player.Init(inputService);
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
            enemy.Init(gameEvents, player, setting);
        }
    }

    private Vector3 GetEnemyRandomPosition()
    {
        return player.transform.position - new Vector3(Random.Range(0,enemySettings.Count),Random.Range(0,enemySettings.Count));
    }
}
