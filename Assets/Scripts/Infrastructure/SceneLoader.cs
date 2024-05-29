using System.Collections.Generic;
using Infrastructure.Level.EventsBus;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class SceneLoader 
    {
        private List<string> _scenes=new List<string>();
        private int _currentScene;
        private readonly IEventBus _event;

        public SceneLoader(IEventBus eventBus, ScenesSettings settings)
        {
            _event=eventBus;
            _event.Subscribe<RestartLevel>(RestartLevel);
            _event.Subscribe<NextLevel>(LoadNextLevel);
            foreach (string scene in settings.Scenes)
            {
                _scenes.Add(scene);
            }
        }
        private void LoadNextLevel(NextLevel obj)
        {
            _currentScene += 1;
            LoadScene();
        }
        private void RestartLevel(RestartLevel obj)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        private void LoadScene()
        {
            int loadedScene = _currentScene;
            if (loadedScene >= _scenes.Count) 
            {
                loadedScene = 0;
            }
            SceneManager.LoadScene(_scenes[loadedScene]);
        }
    }
}
