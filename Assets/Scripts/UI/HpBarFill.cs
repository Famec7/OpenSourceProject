using System;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private PlayerData playerData; // �÷��̾� �����͸� ����
    private Slider _hpSliderBar; // ü���� ǥ���� �̹���

    private void Awake()
    {
        playerData = DataManager.Instance.LoadData();
        _hpSliderBar = GetComponent<Slider>();
    }

    void Update()
    {
        if (playerData != null)
        {
            // ü�� ������ ���� �̹����� fillAmount�� ����
            _hpSliderBar.value = playerData.CurrentHp / playerData.maxHp;
        }
    }
}
