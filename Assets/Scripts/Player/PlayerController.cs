using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData _playerData = null;

    private void Start()
    {
        _playerData = DataManager.Instance.LoadData();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreItem"))
        {
            GameManager.Instance.Score += 10;
#if SCORE_LOG
            Debug.Log($"Score: {GameManager.Instance.Score}");
#endif
        }
    }
}