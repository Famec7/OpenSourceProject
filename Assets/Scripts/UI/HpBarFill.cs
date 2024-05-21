using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public PlayerData playerData; // �÷��̾� �����͸� ����
    public Image hpFillImage; // ü���� ǥ���� �̹���

    private float maxHp; // �ִ� ü��

    void Start()
    {
        if (playerData != null)
        {
            maxHp = playerData.hp; // ���� ���� �� �ִ� ü���� ����
        }
    }

    void Update()
    {
        if (playerData != null && hpFillImage != null)
        {
            // ü�� ������ ���� �̹����� fillAmount�� ����
            hpFillImage.fillAmount = playerData.hp / maxHp;
        }
    }
}
