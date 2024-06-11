using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[System.Serializable]
public class PlayerData
{
    public float speed;

    [SerializeField]
    private float hp;
    public float CurrentHp
    {
        get => hp;
        set
        {
            if (value < 0)
            {
                value = 0;
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
}
