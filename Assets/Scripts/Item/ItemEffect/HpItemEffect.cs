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
        float _tmp = 0;

        while (_tmp <= _hpAmount * 100)
        {
            _tmp += _hpAmount * Time.deltaTime * _recoverySpeed;
            playerData.hp += _tmp;
            yield return null;
        }
    }
}