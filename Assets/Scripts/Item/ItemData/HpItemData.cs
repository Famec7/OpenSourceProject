using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HpItemData", menuName = "ItemData/HpItemData")]
public class HpItemData : ItemDataBase
{
    public int hpAmount;
    public int recoverySpeed;
}
