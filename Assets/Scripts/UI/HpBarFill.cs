using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public PlayerData playerData; // 플레이어 데이터를 참조
    public Image hpFillImage; // 체력을 표시할 이미지

    private float maxHp; // 최대 체력

    void Start()
    {
        if (playerData != null)
        {
            maxHp = playerData.hp; // 게임 시작 시 최대 체력을 설정
        }
    }

    void Update()
    {
        if (playerData != null && hpFillImage != null)
        {
            // 체력 비율에 따라 이미지의 fillAmount를 조정
            hpFillImage.fillAmount = playerData.hp / maxHp;
        }
    }
}
