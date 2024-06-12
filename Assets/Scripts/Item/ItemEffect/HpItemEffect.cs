using System.Collections;
using UnityEngine;

public class HpItemEffect : ItemEffectBase          
{
    private float _hpAmount;                //HpItem�� �� ȸ����
    private float _recoverySpeed;           //HpItem�� �ʴ� ȸ����
    private float _finalHp;                  //���� ȸ����

    public override void Activate(PlayerData playerData)
    {
        _hpAmount = ((HpItemData)ItemData).hpAmount;
        _recoverySpeed = ((HpItemData)ItemData).recoverySpeed;
        ((HpItemData)ItemData).duration = _hpAmount / _recoverySpeed;   //HpItem�� ���� �ð� ����
        
        _finalHp = _hpAmount + playerData.CurrentHp;          //ȸ���ǰ� �� ���� playerhp
        if(_finalHp > playerData.maxHp)                      //ȸ���ǰ� �� ���� playerhp�� �ִ� hp���� Ŭ ���
        {
            _finalHp = playerData.maxHp;                      //�ִ� hp�� ����
        }
    }

    public override void Deactivate(PlayerData playerData)
    {
        ;
    }

    public override void UpdateEffect(PlayerData playerData)
    {
        playerData.CurrentHp += _recoverySpeed * Time.deltaTime;       //playerhp�� ���� ȸ��
    }
}