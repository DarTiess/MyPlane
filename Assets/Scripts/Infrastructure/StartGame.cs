using System.Collections.Generic;
using Data;
using Enemy;
using Input;
using Player;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] private SceneSettings sceneSettings;
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
        private DataSaver dataSaver;
        private SceneLoader sceneLoader;

        private void Awake()
        { 
            // sceneLoader.StartLevel();
            inputService = InputService();
            dataSaver = new DataSaver();
            sceneLoader = new SceneLoader(dataSaver, sceneSettings);
        
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
            ui.Init(gameStateEvents, gameStateEvents, dataSaver);
        }
        private void CreatePlayer()
        {
            player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            player.Init(inputService,gameStateEvents, gameStateEvents);
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
            return player.transform.position - new Vector3(Random.Range(1,enemySettings.Count),Random.Range(1,enemySettings.Count));
        }
    }
}
