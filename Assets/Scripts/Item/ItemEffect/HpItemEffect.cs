using System.Collections;
using UnityEngine;

public class HpItemEffect : ItemEffectBase          
{
    private float _hpAmount;                //HpItem의 총 회복량
    private float _recoverySpeed;           //HpItem의 초당 회복량

    public override void Activate(PlayerData playerData)
    {
        _hpAmount = ((HpItemData)ItemData).hpAmount;
        _recoverySpeed = ((HpItemData)ItemData).recoverySpeed;
        ((HpItemData)ItemData).duration = _hpAmount / _recoverySpeed;   //HpItem의 지속 시간 설정
        StartCoroutine(IE_RecoveryHp(playerData));
    }

    public override void Deactivate()
    {
        ;
    }

    private IEnumerator IE_RecoveryHp(PlayerData playerData)
    {
        float finalHp = _hpAmount + playerData.hp;          //회복되고 난 후의 playerhp

        while (playerData.hp < finalHp)                     //예상 회복량까지 회복 반복
        {
            playerData.hp += _recoverySpeed * Time.deltaTime;       //playerhp를 고르게 회복
            yield return null;
        }
    }
}