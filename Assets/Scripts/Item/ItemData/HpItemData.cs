using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HpItemData", menuName = "ItemData/HpItemData")]
public class HpItemData : ItemDataBase 
{
    public int hpAmount;                        //회복 아이템의 총 hp 회복량
    public int recoverySpeed;                   //회복 아이템의 초당 hp 회복량

}
