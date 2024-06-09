using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
    }
    
    private void Update()
    {
        _scoreText.text = $"{GameManager.Instance.Score:F0}";
    }
}