using System.Collections;
using UnityEngine;

public class HpItemEffect : ItemEffectBase          
{
    private float _hpAmount;                //HpItem�� �� ȸ����
    private float _recoverySpeed;           //HpItem�� �ʴ� ȸ����

    public override void Activate(PlayerData playerData)
    {
        _hpAmount = ((HpItemData)ItemData).hpAmount;
        _recoverySpeed = ((HpItemData)ItemData).recoverySpeed;
        ((HpItemData)ItemData).duration = _hpAmount / _recoverySpeed;   //HpItem�� ���� �ð� ����
        StartCoroutine(IE_RecoveryHp(playerData));
    }

    public override void Deactivate()
    {
        ;
    }

    private IEnumerator IE_RecoveryHp(PlayerData playerData)
    {
        float finalHp = _hpAmount + playerData.hp;          //ȸ���ǰ� �� ���� playerhp

        while (playerData.hp < finalHp)                     //���� ȸ�������� ȸ�� �ݺ�
        {
            playerData.hp += _recoverySpeed * Time.deltaTime;       //playerhp�� ���� ȸ��
            yield return null;
        }
    }
}