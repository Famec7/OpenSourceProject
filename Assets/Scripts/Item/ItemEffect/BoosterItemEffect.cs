using System.Collections;
using UnityEngine;

public class BoosterItemEffect : ItemEffectBase          
{
    private float _originSpeed;

    public override void Activate(PlayerData playerData)
    {
        _originSpeed = playerData.speed;
        playerData.speed = ((BoosterItemData)ItemData).boosterSpeed;
    }

    public override void Deactivate(PlayerData playerData)
    {
        playerData.speed = _originSpeed;
    }
}