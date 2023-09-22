using System.Collections.Generic;
using Configs;
using Data;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class SceneLoader 
    {
        private IChangeScene _sceneData;
        private List<string> _scenes=new List<string>();
        private int _currentScene;
        public SceneLoader(IChangeScene sceneData, SceneSettings settings)
        {
            _sceneData = sceneData;
            foreach (string scene in settings.Scenes)
            {
                _scenes.Add(scene);
            }
        }
        public void LoadNextLevel()
        {
            _currentScene += 1;
            _sceneData.ChangeCurrentScene(_currentScene);
       
            LoadScene();
        }

        private void LoadScene()
        {
            int sceneNumber = _sceneData.GetCurrentScene();
            if (sceneNumber == 0)
            {
                _currentScene = 1;
                _sceneData.ChangeCurrentScene(_currentScene);
            }
            int loadedScene = sceneNumber;
            if (loadedScene <= _scenes.Count) 
            { 
                loadedScene -= 1;
            }
            else
            {
                loadedScene = 0;
            }
            SceneManager.LoadScene(_scenes[loadedScene]);
        }
        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
