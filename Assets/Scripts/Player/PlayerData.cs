using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

[System.Serializable]
public class PlayerData
{
    public float initialSpeed;
    public float speed;

    [SerializeField]
    private float hp;
    public float CurrentHp
    {
        get => hp;
        set
        {
            if (value <= 0)
            {
                value = 0;
                SceneController.Instance.LoadScene(SceneName.GameOver);
            }
            else if (value > maxHp)
            {
                value = maxHp;
            }
            
            hp = value;
        }
    }

    public int maxHp;
    
    public bool IsInvincible { get; set; }

    public UnityAction onGiantModeStart;
    public UnityAction onGiantModeStop;
    
    public void Init()
    {
        speed = initialSpeed;
        CurrentHp = maxHp;
        IsInvincible = false;
    }
}
