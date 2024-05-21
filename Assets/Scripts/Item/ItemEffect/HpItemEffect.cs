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
        playerData.hp += _hpAmount;
        StartCoroutine(IE_RecoveryHp(playerData));
    }

    public override void Deactivate()
    {
        Debug.Log("TestItemEffect deactivated!");   //debug
    }

    private IEnumerator IE_RecoveryHp(PlayerData playerData)
    {
        while (true)
        {
            playerData.hp += _hpAmount * Time.deltaTime * _recoverySpeed;
            yield return null;
        }
    }
}