using System.Collections;
using UnityEngine;

public class HpItemEffect : ItemEffectBase
{
    private float _hpAmount;
    private float _recoverySpeed;

    public override void Activate(PlayerData playerData)
    {
        Debug.Log("TestItemEffect activated!");     //debug

        _hpAmount = ((HpItemData)ItemData).hpAmount;
        _recoverySpeed = ((HpItemData)ItemData).recoverySpeed;
        ((HpItemData)ItemData).duration = _hpAmount / _recoverySpeed;
        StartCoroutine(IE_RecoveryHp(playerData));
    }

    public override void Deactivate()
    {
        ;
    }

    private IEnumerator IE_RecoveryHp(PlayerData playerData)
    {
        float finalHp = _hpAmount + playerData.hp;

        while (playerData.hp < finalHp)
        {
            playerData.hp += _recoverySpeed * Time.deltaTime;
            yield return null;
        }
    }
}