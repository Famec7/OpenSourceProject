using System.Collections;
using UnityEngine;

public class BoosterItemEffect : ItemEffectBase          
{
    public override void Activate(PlayerData playerData)
    {
        playerData.speed = ((BoosterItemData)ItemData).boosterSpeed;
    }

    public override void Deactivate(PlayerData playerData)
    {
        playerData.speed = playerData.initialSpeed;
    }
}