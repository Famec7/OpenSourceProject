using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
    Lobby,
    InGame,
    GameOver
}

public class SceneController : Singleton<SceneController>
{
    public override void Init()
    {
        ;
    }
    
    public void LoadScene(SceneName sceneName)
    {
        SceneManager.LoadScene((int)sceneName);
        
        switch (sceneName)
        {
            case SceneName.Lobby:
                break;
            case SceneName.InGame:
                GameManager.Instance.Init();
                ObjectPoolManager.Instance.Init();
                DataManager.Instance.Init();
                break;
            case SceneName.GameOver:
                AudioManager.Instance.StopBGM();
                break;
            default:
                break;
        }
    }
}