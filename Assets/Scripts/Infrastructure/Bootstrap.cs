using System.Collections.Generic;
using Configs;
using Data;
using Enemy;
using Input;
using Player;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private SceneSettings _sceneSettings;
        [SerializeField] private PlayerContainer _playerPrefab;
        [SerializeField] private PlayerConfigs _playerConfig;
        [SerializeField] private UIController _uiPrefab;
        [SerializeField] private EnemyContainer _enemyPrefab;
        [SerializeField] private List<EnemySetting> _enemySettings;

        private CameraFollow.CameraFollow _mainCamera;
        private IInputService _inputService;
        private GameEvents.GameStateEvents _gameStateEvents;
        private UIController _ui;
        private PlayerContainer _player;
        private DataSaver _dataSaver;
        private SceneLoader _sceneLoader;

        private void Awake()
        { 
            // sceneLoader.StartLevel();
            _inputService = InputService();
            _dataSaver = new DataSaver(_playerConfig);
            _sceneLoader = new SceneLoader(_dataSaver, _sceneSettings);
        
            CreateGameState();
            CreateCanvas();
            CreatePlayer();
            InitCamera();
            CreateEnemies();
            _gameStateEvents.OnStartGame();
            DontDestroyOnLoad(this);
        }
        private void CreateGameState()
        {
            _gameStateEvents = new GameEvents.GameStateEvents();
            _gameStateEvents.Init(_sceneLoader,_dataSaver);
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
            _ui = Instantiate(_uiPrefab);
            _ui.Init(_gameStateEvents, _gameStateEvents, _dataSaver);
        }
        private void CreatePlayer()
        {
            _player = Instantiate(_playerPrefab, transform.position, Quaternion.identity);
            _player.Init(_inputService,_gameStateEvents, _playerConfig, _dataSaver);
        }
        private void InitCamera()
        {
            _mainCamera = Camera.main.GetComponent<CameraFollow.CameraFollow>();
            _mainCamera.Init(_player.transform);
        }
        private void CreateEnemies()
        {
            foreach (EnemySetting setting in _enemySettings)
            {
                EnemyContainer enemy = Instantiate(_enemyPrefab, GetEnemyRandomPosition(), Quaternion.identity);
                enemy.Init(_gameStateEvents, _player.transform, setting);
            }
        }
        private Vector3 GetEnemyRandomPosition()
        {
            return _player.transform.position - new Vector3(Random.Range(1,_enemySettings.Count),Random.Range(1,_enemySettings.Count));
        }
    }
}
