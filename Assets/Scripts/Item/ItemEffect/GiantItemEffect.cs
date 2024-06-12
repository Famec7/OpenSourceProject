using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantItemEffect : ItemEffectBase
{
    public override void Activate(PlayerData playerData)
    {
        playerData.onGiantModeStart();
    }

    public override void Deactivate(PlayerData playerData)
    {
        playerData.onGiantModeStop();
    }

    public override void UpdateEffect(PlayerData playerData)
    {
        ;
    }
}
