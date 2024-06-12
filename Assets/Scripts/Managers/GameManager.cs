using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private float _score;
    private readonly float _scorePerSecond = 1f;
    
    private PlayerData _playerData = null;

    public float Score
    {
        get => _score;
        private set => _score = value;
    }


    public override void Init()
    {
        _score = 0;
        _playerData = DataManager.Instance.LoadData();
        _playerData.Init();
    }

    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        var gameManager = Instance;
        gameManager.Init();
    }

    private void Update()
    {
        Score += _scorePerSecond * Time.deltaTime;
    }
}