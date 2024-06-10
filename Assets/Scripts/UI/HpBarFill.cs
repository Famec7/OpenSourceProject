using System;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private PlayerData playerData; // 플레이어 데이터를 참조
    private Slider _hpSliderBar; // 체력을 표시할 이미지

    private void Awake()
    {
        playerData = DataManager.Instance.LoadData();
        _hpSliderBar = GetComponent<Slider>();
    }

    void Update()
    {
        if (playerData != null)
        {
            // 체력 비율에 따라 이미지의 fillAmount를 조정
            _hpSliderBar.value = playerData.CurrentHp / playerData.maxHp;
        }
    }
}
