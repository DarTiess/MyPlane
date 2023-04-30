using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelManager", menuName = "LevelManager", order = 51)]
public class SceneLoader : ScriptableObject
{
    public List<string> scenes;

    public int CurrentScene
    {
        get { return PlayerPrefs.GetInt("CurrentScene"); }
        set { PlayerPrefs.SetInt("CurrentScene", value); }
    }

    public void StartLevel()
    {
        if (CurrentScene == 0) CurrentScene = 1;
        LoadScene();
    }

    public void LoadNextLevel()
    {
        CurrentScene += 1;
       
        LoadScene();
    }

    public void LoadScene()
    {
        if (CurrentScene == 0) CurrentScene = 1;
        int loadedScene = CurrentScene;
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
