using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData _playerData = null;

    private void Start()
    {
        _playerData = DataManager.Instance.LoadData();
    }
}