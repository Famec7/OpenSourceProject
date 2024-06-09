using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private float _score;
    private readonly float _scorePerSecond = 1f;

    public float Score
    {
        get => _score;
        private set => _score = value;
    }


    protected override void Init()
    {
        _score = 0;
    }

    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        var gameManager = Instance;
    }

    private void Update()
    {
        Score += _scorePerSecond * Time.deltaTime;
    }
}