using System.Collections;
using UnityEngine;

public class HpItemEffect : ItemEffectBase          
{
    private float _hpAmount;                //HpItem의 총 회복량
    private float _recoverySpeed;           //HpItem의 초당 회복량
    private float _finalHp;                  //예상 회복량

    public override void Activate(PlayerData playerData)
    {
        _hpAmount = ((HpItemData)ItemData).hpAmount;
        _recoverySpeed = ((HpItemData)ItemData).recoverySpeed;
        ((HpItemData)ItemData).duration = _hpAmount / _recoverySpeed;   //HpItem의 지속 시간 설정
        
        _finalHp = _hpAmount + playerData.CurrentHp;          //회복되고 난 후의 playerhp
        if(_finalHp > playerData.maxHp)                      //회복되고 난 후의 playerhp가 최대 hp보다 클 경우
        {
            _finalHp = playerData.maxHp;                      //최대 hp로 설정
        }
    }

    public override void Deactivate(PlayerData playerData)
    {
        ;
    }

    public override void UpdateEffect(PlayerData playerData)
    {
        playerData.CurrentHp += _recoverySpeed * Time.deltaTime;       //playerhp를 고르게 회복
    }
}