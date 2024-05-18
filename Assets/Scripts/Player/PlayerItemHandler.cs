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
        itemEffect.Activate(_data);
        _activeItems.Add(itemEffect);
        StartCoroutine(IE_DeactivateItem(itemEffect));
    }
    
    private IEnumerator IE_DeactivateItem(ItemEffectBase itemEffect)
    {
        yield return new WaitForSeconds(itemEffect.ItemData.duration);
        itemEffect.Deactivate();
        _activeItems.Remove(itemEffect);
        Destroy(itemEffect.gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            if(other.TryGetComponent<ItemEffectBase>(out var itemEffect))
            {
                UseItem(itemEffect);
                other.gameObject.SetActive(false);
            }
        }
    }
}