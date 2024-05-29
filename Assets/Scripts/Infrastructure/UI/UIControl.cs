using Infrastructure.Level.EventsBus;
using Infrastructure.Level.EventsBus.Signals;
using UI.UIPanels;
using UnityEngine;

namespace UI
{
    public class UIControl : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private StartMenu panelMenu;
        [SerializeField] private GamePanel panelInGame;
       // [SerializeField] private WinPanel panelWin;  
        [SerializeField] private LostPanel panelLost;
        
        private IEventBus _events;

        public void Init(IEventBus events)
        {
            _events = events;
           
            _events.Subscribe<LevelStart>(OnLevelStart);
            _events.Subscribe<LevelWin>(OnLevelWin);
            _events.Subscribe<LevelLost>(OnLevelLost);
            
            panelMenu.ClickedPanel += OnPlayGame;
            panelLost.ClickedPanel += RestartGame;
            panelInGame.ClickedPanel += OnPauseGame;
           // panelWin.ClickedPanel += LoadNextLevel;
            StartLevel();
        }

        private void OnDestroy()
        {
            _events.Unsubscribe<LevelStart>(OnLevelStart);
            _events.Unsubscribe<LevelWin>(OnLevelWin);
            _events.Unsubscribe<LevelLost>(OnLevelLost);
            panelMenu.ClickedPanel -= OnPlayGame;
            panelLost.ClickedPanel -= RestartGame;
            panelInGame.ClickedPanel -= OnPauseGame;
           // panelWin.ClickedPanel -= LoadNextLevel;
        }

        private void StartLevel()
        {
            HideAllPanels();
            panelMenu.Show();
        }

        private void OnLevelLost(LevelLost obj)
        {
            Debug.Log("Level Lost");  
            HideAllPanels();
            panelLost.Show();
        }

        private void OnLevelWin(LevelWin obj)
        {
            Debug.Log("Level Win"); 
            HideAllPanels();
          //  panelWin.Show();  
        }

        private void OnLevelStart(LevelStart obj)
        {
          StartLevel();
        }

        private void OnPauseGame()
        {
            _events.Invoke(new PauseGame());
        }

        private void OnPlayGame()
        {
            _events.Invoke(new PlayGame());
            HideAllPanels(); 
            panelInGame.Show();         
        }
        private void LoadNextLevel()
        {
            _events.Invoke(new NextLevel());
        }

        private void RestartGame()
        {
            _events.Invoke(new RestartLevel());
        }

        private void HideAllPanels()
        {
            panelMenu.Hide();
            panelLost.Hide();
          //  panelWin.Hide();
            panelInGame.Hide();
        }
    
    }
}
