using System.Collections.Generic;
using Data;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class SceneLoader 
    {
        private IDataSaver dataSaver;
        private List<string> scenes=new List<string>();
        public SceneLoader(IDataSaver dataSaver, SceneSettings settings)
        {
            this.dataSaver = dataSaver;
            foreach (string scene in settings.scenes)
            {
                scenes.Add(scene);
            }
        }
        public void StartLevel()
        {
            if (dataSaver.CurrentScene == 0) dataSaver.CurrentScene = 1;
            LoadScene();
        }
        public void LoadNextLevel()
        {
            dataSaver.CurrentScene += 1;
       
            LoadScene();
        }
        public void LoadScene()
        {
            if (dataSaver.CurrentScene == 0) dataSaver.CurrentScene = 1;
            int loadedScene = dataSaver.CurrentScene;
            if (loadedScene <= scenes.Count) 
            { 
                loadedScene -= 1;
            }
            else
            {
                loadedScene = 0;
            }
            SceneManager.LoadScene(scenes[loadedScene]);
        }
        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
