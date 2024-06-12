using System.Collections;
using UnityEngine;

public class BoosterItemEffect : ItemEffectBase          
{
    public override void Activate(PlayerData playerData)
    {
        playerData.speed = ((BoosterItemData)ItemData).boosterSpeed;
        playerData.IsInvincible = true;
    }

    public override void Deactivate(PlayerData playerData)
    {
        playerData.speed = playerData.initialSpeed;
        playerData.IsInvincible = false;
    }
}