using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int _score;

    public int Score
    {
        get => _score;
        set => _score = value;
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
}