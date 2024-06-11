using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemHandler : MonoBehaviour
{
    private PlayerData _data = null;
    private List<ItemEffectBase> _activeItems = new List<ItemEffectBase>();

    private void Start()
    {
        _data = DataManager.Instance.LoadData();
    }
    
    private void UseItem(ItemEffectBase itemEffect)
    {
        itemEffect.Activate(_data); // 아이템 효과 활성화
        _activeItems.Add(itemEffect); // 활성화된 아이템 리스트에 추가
        StartCoroutine(IE_DeactivateItem(itemEffect)); // 지속시간 이후 아이템 비활성화
    }
    
    // 아이템 비활성화 코루틴 (지속시간 이후 아이템 비활성화)
    private IEnumerator IE_DeactivateItem(ItemEffectBase itemEffect)
    {
        yield return new WaitForSeconds(itemEffect.ItemData.duration);
        itemEffect.Deactivate(_data);
        _activeItems.Remove(itemEffect);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            if(other.TryGetComponent<ItemEffectBase>(out var itemEffect))
            {
                UseItem(itemEffect);
                ObjectPoolManager.Instance.ReturnObject(other.gameObject.GetComponent<ItemEffectBase>());
            }
        }
    }
}