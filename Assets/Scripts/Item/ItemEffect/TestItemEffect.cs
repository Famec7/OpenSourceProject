using UnityEngine;

public class TestItemEffect : ItemEffectBase
{
    public override void Activate(PlayerData playerData)
    {
        Debug.Log("TestItemEffect activated!");
    }

    public override void Deactivate()
    {
        Debug.Log("TestItemEffect deactivated!");
    }
}