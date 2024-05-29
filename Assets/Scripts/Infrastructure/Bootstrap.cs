using Data;
using Player;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private UIControl uiPrefab;
        
        private CameraFollow.CameraFollow _mainCamera;
        private PlayerView _player;
        private DataSaver _dataSaver;
        private SceneLoader _sceneLoader;
        private Factory _factory;
        private EnemyFactory _enemyFactory;

        [Inject]
        public void Construct(Factory factory, EnemyFactory enemyFactory)
        {
            _factory = factory;
            _enemyFactory = enemyFactory;
        }
        private void Awake()
        {
            CreateCanvas();
            CreatePlayer();
            InitCamera();
            CreateEnemies();
            DontDestroyOnLoad(this);
        }
        private void CreateCanvas()
        {
           _factory.CreateUI(uiPrefab);
        }
        private void CreatePlayer()
        {
           _player= _factory.CreatePlayer(transform);
        }
        private void InitCamera()
        {
            _mainCamera = Camera.main.GetComponent<CameraFollow.CameraFollow>();
            _mainCamera.Init(_player.transform);
        }
        private void CreateEnemies()
        {
            _enemyFactory.CreateEnemies(_player.transform);
        }
       
    }
}
